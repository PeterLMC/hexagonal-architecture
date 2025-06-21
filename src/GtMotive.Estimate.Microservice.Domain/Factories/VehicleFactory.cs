using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Factories
{
    /// <summary>
    /// Factory responsible for creating instances of <see cref="IVehicle"/>.
    /// </summary>
    public class VehicleFactory : IVehicleFactory
    {
        /// <summary>
        /// Creates a new instance of <see cref="IVehicle"/> with a generated vehicle ID.
        /// </summary>
        /// <param name="model">The model name of the vehicle.</param>
        /// <param name="manufactureDate">The manufacturing date of the vehicle.</param>
        /// <returns>A new <see cref="IVehicle"/> instance.</returns>
        public IVehicle CreateVehicle(string model, DateTime manufactureDate)
        {
            return new VehicleEntity(VehicleId.NewId(), model, new ManufactureDate(manufactureDate));
        }
    }
}
