using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Use case for renting a vehicle.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="outputPort">The output port for the use case.</param>
    /// <param name="logger">The logger for the application.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public class RentVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IUnitOfWork unitOfWork,
        IRentVehicleOutputPort outputPort,
        IAppLogger<RentVehicleUseCase> logger) : IRentVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IRentVehicleOutputPort _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        private readonly IAppLogger<RentVehicleUseCase> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Executes the vehicle rental process.
        /// </summary>
        /// <param name="input">The input data for renting a vehicle.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        public async Task Execute(RentVehicleInput input)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(input);
                _logger.LogDebug("Executing RentVehicleUseCase for VehicleId: {VehicleId}, CustomerId: {CustomerId}", input.VehicleId, input.CustomerId);

                if (await _vehicleRepository.HasActiveRental(input.CustomerId))
                {
                    _logger.LogWarning("Customer {CustomerId} already has an active rental.", input.CustomerId);
                    throw new CustomerAlreadyHasRentalException($"Customer {input.CustomerId} already has an active rental.");
                }

                var vehicle = await _vehicleRepository.GetBy(input.VehicleId);
                if (vehicle == null)
                {
                    _logger.LogWarning("Vehicle {VehicleId} not found.", input.VehicleId);
                    _outputPort.NotFoundHandle($"Vehicle {input.VehicleId} not found.");
                    return;
                }

                vehicle.Rent(input.CustomerId);
                await _vehicleRepository.Update(vehicle);
                await _unitOfWork.Save();

                var output = new RentVehicleOutput(input.VehicleId, input.CustomerId);
                _outputPort.StandardHandle(output);
                _logger.LogInformation("Vehicle {VehicleId} rented to Customer {CustomerId}.", input.VehicleId, input.CustomerId);
            }
            catch (VehicleAlreadyRentedException ex)
            {
                _logger.LogError(ex, "Error renting vehicle: {Message}", ex.Message);
                _outputPort.AlreadyRentedHandle(ex.Message);
            }
            catch (CustomerAlreadyHasRentalException ex)
            {
                _logger.LogError(ex, "Error renting vehicle: {Message}", ex.Message);
                _outputPort.CustomerHasRentalHandle(ex.Message);
            }
        }
    }
}
