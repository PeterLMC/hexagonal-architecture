using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Input data for renting a vehicle use case.
    /// </summary>
    public class RentVehicleInput(VehicleId vehicleId, CustomerId customerId) : IUseCaseInput
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
