using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Use case for returning a vehicle.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="outputPort">The output port for the use case.</param>
    /// <param name="logger">The logger for the use case.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public class ReturnVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IUnitOfWork unitOfWork,
        IReturnVehicleOutputPort outputPort,
        IAppLogger<ReturnVehicleUseCase> logger) : IReturnVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IReturnVehicleOutputPort _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        private readonly IAppLogger<ReturnVehicleUseCase> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Executes the vehicle return operation.
        /// </summary>
        /// <param name="input">The input data for returning a vehicle.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        public async Task Execute(ReturnVehicleInput input)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(input);
                _logger.LogDebug("Executing ReturnVehicleUseCase for VehicleId: {VehicleId}", input.VehicleId);
                var vehicle = await _vehicleRepository.GetBy(input.VehicleId);
                if (vehicle == null)
                {
                    _logger.LogWarning("Vehicle {VehicleId} not found.", input.VehicleId);
                    _outputPort.NotFoundHandle($"Vehicle {input.VehicleId} not found.");
                    return;
                }

                if (!vehicle.IsRented)
                {
                    _logger.LogWarning("Vehicle {VehicleId} is not rented.", input.VehicleId);
                    _outputPort.NotRentedHandle($"Vehicle {input.VehicleId} is not rented.");
                    return;
                }

                vehicle.ReturnVehicle();
                await _vehicleRepository.Update(vehicle);
                await _unitOfWork.Save();

                var output = new ReturnVehicleOutput(input.VehicleId);
                _outputPort.StandardHandle(output);
                _logger.LogInformation("Vehicle {VehicleId} returned successfully.", input.VehicleId);
            }
            catch (DomainException ex)
            {
                _logger.LogError(ex, "Error returning vehicle: {Message}", ex.Message);
                _outputPort.NotFoundHandle("An unexpected error occurred.");
            }
        }
    }
}
