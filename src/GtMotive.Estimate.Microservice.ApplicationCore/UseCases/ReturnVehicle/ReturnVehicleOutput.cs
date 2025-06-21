using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output data for the return vehicle use case.
    /// </summary>
    /// <param name="vehicleId">The ID of the return vehicle.</param>
    public class ReturnVehicleOutput(VehicleId vehicleId) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the ID of the rent vehicle.
        /// </summary>
        public VehicleId VehicleId { get; } = vehicleId;
    }
}
