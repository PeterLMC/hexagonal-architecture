using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Interface for vehicle repository operations.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds a new vehicle to the repository.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Add(IVehicle vehicle);

        /// <summary>
        /// Retrieves a vehicle by its ID.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to retrieve.</param>
        /// <returns>A task that returns the vehicle or null if not found.</returns>
        Task<IVehicle> GetBy(VehicleId vehicleId);

        /// <summary>
        /// Updates an existing vehicle in the repository.
        /// </summary>
        /// <param name="vehicle">The vehicle to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Update(IVehicle vehicle);

        /// <summary>
        /// Retrieves a list of available vehicles.
        /// </summary>
        /// <returns>A task that returns a list of available vehicles.</returns>
        Task<List<IVehicle>> GetAvailableVehicles();

        /// <summary>
        /// Checks if a customer has an active rental.
        /// </summary>
        /// <param name="customerId">The ID of the customer to check.</param>
        /// <returns>A task that returns true if the customer has an active rental, false otherwise.</returns>
        Task<bool> HasActiveRental(CustomerId customerId);
    }
}
