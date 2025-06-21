using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Input data for return a vehicle use case.
    /// </summary>
    public class ReturnVehicleInput(VehicleId vehicleId) : IUseCaseInput
    {
        /// <summary>
        /// Gets the ID of the return vehicle.
        /// </summary>
        public VehicleId VehicleId { get; } = vehicleId;
    }
}
