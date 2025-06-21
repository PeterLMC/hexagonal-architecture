using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Input data for creating a vehicle use case.
    /// </summary>
    public class CreateVehicleInput(string model, DateTime manufactureDate) : IUseCaseInput
    {
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
