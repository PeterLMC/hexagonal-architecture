using System;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Interface for creating vehicle instances.
    /// </summary>
    public interface IVehicleFactory
    {
        /// <summary>
        /// Creates a new vehicle with the specified model and manufacture date.
        /// </summary>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="manufactureDate">The manufacture date of the vehicle.</param>
        /// <returns>A new vehicle instance.</returns>
        IVehicle CreateVehicle(string model, DateTime manufactureDate);
    }
}
