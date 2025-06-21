namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output port for the create vehicle use case.
    /// </summary>
    public interface IRentVehicleOutputPort : IOutputPortStandard<RentVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles messages when already rented vehicle operation.
        /// </summary>
        /// <param name="message">The error message to handle.</param>
        void AlreadyRentedHandle(string message);

        /// <summary>
        /// Handles messages when the customer has rental vehicle operation.
        /// </summary>
        /// <param name="message">The error message to handle.</param>
        void CustomerHasRentalHandle(string message);
    }
}
