using System;
using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Output data for the list available vehicles use case.
    /// </summary>
    /// <param name="vehicles">The collection of available vehicles.</param>
    /// <exception cref="ArgumentNullException">Thrown when vehicles is null.</exception>
    public class ListAvailableVehiclesOutput(IEnumerable<VehicleDto> vehicles) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the collection of available vehicles.
        /// </summary>
        public IEnumerable<VehicleDto> Vehicles { get; } = vehicles;
    }
}
