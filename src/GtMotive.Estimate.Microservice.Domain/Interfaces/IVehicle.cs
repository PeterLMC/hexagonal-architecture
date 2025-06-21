using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Interface for vehicle entities in the rental system.
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Gets the unique identifier of the vehicle.
        /// </summary>
        VehicleId Id { get; }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        string Model { get; }

        /// <summary>
        /// Gets the manufacture date of the vehicle.
        /// </summary>
        ManufactureDate ManufactureDate { get; }

        /// <summary>
        /// Gets a value indicating whether the vehicle is currently rented.
        /// </summary>
        bool IsRented { get; }

        /// <summary>
        /// Gets the identifier of the customer renting the vehicle, if any.
        /// </summary>
        CustomerId? RentedBy { get; }

        /// <summary>
        /// Rents the vehicle to a customer.
        /// </summary>
        /// <param name="customerId">The identifier of the customer renting the vehicle.</param>
        void Rent(CustomerId customerId);

        /// <summary>
        /// Returns the vehicle from being rented.
        /// </summary>
        void ReturnVehicle();
    }
}
