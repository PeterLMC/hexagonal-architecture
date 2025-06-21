using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Output data for the create vehicle use case.
    /// </summary>
    /// <param name="vehicleId">The ID of the created vehicle.</param>
    /// <param name="model">The model of the created vehicle.</param>
    public class CreateVehicleOutput(VehicleId vehicleId, string model) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the ID of the created vehicle.
        /// </summary>
        public VehicleId VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the model of the created vehicle.
        /// </summary>
        public string Model { get; } = model ?? throw new ArgumentNullException(nameof(model));
    }
}
