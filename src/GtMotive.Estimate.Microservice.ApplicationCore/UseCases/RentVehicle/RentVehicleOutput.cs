using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output data for the renting vehicle use case.
    /// </summary>
    /// <param name="vehicleId">The ID of the rent vehicle.</param>
    /// <param name="customerId">The customer.</param>
    public class RentVehicleOutput(VehicleId vehicleId, CustomerId customerId) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the ID of the rent vehicle.
        /// </summary>
        public VehicleId VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets ID of the customer.
        /// </summary>
        public CustomerId CustomerId { get; } = customerId;
    }
}
