using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Use case for listing available vehicles.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ListAvailableVehiclesUseCase"/> class.
    /// </remarks>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="outputPort">The output port for the use case.</param>
    /// <param name="logger">The logger for the use case.</param>
    public class ListAvailableVehiclesUseCase(
        IVehicleRepository vehicleRepository,
        IListAvailableVehiclesOutputPort outputPort,
        IAppLogger<ListAvailableVehiclesUseCase> logger) : IListAvailableVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        private readonly IListAvailableVehiclesOutputPort _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        private readonly IAppLogger<ListAvailableVehiclesUseCase> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Executes the list available vehicles operation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Execute()
        {
            _logger.LogDebug("Executing ListAvailableVehiclesUseCase");
            var vehicles = await _vehicleRepository.GetAvailableVehicles();
            var vehicleDtos = vehicles.Select(v => new VehicleDto(v.Id.ToGuid(), v.Model, v.ManufactureDate.ToDateTime())).ToList();
            var output = new ListAvailableVehiclesOutput(vehicleDtos);
            _outputPort.StandardHandle(output);
            _logger.LogInformation("Retrieved {Count} available vehicles.", vehicleDtos.Count);
        }
    }
}
