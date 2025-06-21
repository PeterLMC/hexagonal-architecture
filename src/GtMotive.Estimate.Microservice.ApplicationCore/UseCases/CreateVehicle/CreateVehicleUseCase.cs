using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Use case for creating a vehicle.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="outputPort">The output port for the use case.</param>
    /// <param name="vehicleFactory">The vehicle factory.</param>
    /// <param name="logger">The logger for the application.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public class CreateVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IUnitOfWork unitOfWork,
        ICreateVehicleOutputPort outputPort,
        IVehicleFactory vehicleFactory,
        IAppLogger<CreateVehicleUseCase> logger) : ICreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly ICreateVehicleOutputPort _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        private readonly IVehicleFactory _vehicleFactory = vehicleFactory ?? throw new ArgumentNullException(nameof(vehicleFactory));
        private readonly IAppLogger<CreateVehicleUseCase> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Executes the vehicle creation process.
        /// </summary>
        /// <param name="input">The input data for creating a vehicle.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        public async Task Execute(CreateVehicleInput input)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(input);
                _logger.LogDebug("Creating vehicle with model: {Model}", input.Model);
                var vehicle = _vehicleFactory.CreateVehicle(input.Model, input.ManufactureDate);
                await _vehicleRepository.Add(vehicle);
                await _unitOfWork.Save();
                var output = new CreateVehicleOutput(vehicle.Id, vehicle.Model);
                _outputPort.StandardHandle(output);
                _logger.LogInformation("Vehicle {VehicleId} created successfully.", vehicle.Id);
            }
            catch (DomainException ex)
            {
                _logger.LogError(ex, "Error creating vehicle: {Message}", ex.Message);
                _outputPort.ErrorHandle(ex.Message);
            }
        }
    }
}
