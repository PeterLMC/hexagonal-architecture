using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Data transfer object for vehicle information.
    /// </summary>
    /// <param name="vehicleId">The ID of the vehicle.</param>
    /// <param name="model">The model of the vehicle.</param>
    /// <param name="manufactureDate">The manufacture date of the vehicle.</param>
    /// <exception cref="ArgumentNullException">Thrown when model is null.</exception>
    public class VehicleDto(Guid vehicleId, string model, DateTime manufactureDate)
    {
        /// <summary>
        /// Gets the ID of the vehicle.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string Model { get; } = model ?? throw new ArgumentNullException(nameof(model));

        /// <summary>
        /// Gets the manufacture date of the vehicle.
        /// </summary>
        public DateTime ManufactureDate { get; } = manufactureDate;
    }
}
