using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle entity with identity, model, and manufacturing date.
    /// </summary>
    public class VehicleEntity(VehicleId id, string model, ManufactureDate manufactureDate) : IVehicle
    {
        /// <summary>
        /// Gets the ID of the vehicle.
        /// </summary>
        public VehicleId Id { get; private set; } = id;

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string Model { get; private set; } = model ?? throw new DomainException("Vehicle model cannot be null.");

        /// <summary>
        /// Gets the manufacture data of the vehicle.
        /// </summary>
        public ManufactureDate ManufactureDate { get; private set; } = manufactureDate;

        /// <summary>
        /// Gets a value indicating whether if the vehicle is rented.
        /// </summary>
        public bool IsRented { get; private set; }

        /// <summary>
        /// Gets ID of the customer.
        /// </summary>
        public CustomerId? RentedBy { get; private set; }

        /// <summary>
        /// Rents the vehicle to a customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        public void Rent(CustomerId customerId)
        {
            if (IsRented)
            {
                throw new VehicleAlreadyRentedException($"Vehicle {Id} is already rented.");
            }

            IsRented = true;
            RentedBy = customerId;
        }

        /// <summary>
        /// Returns the vehicle from being rented.
        /// </summary>
        public void ReturnVehicle()
        {
            IsRented = false;
            RentedBy = null;
        }
    }
}
