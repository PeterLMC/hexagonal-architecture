namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output port for the return vehicle use case.
    /// </summary>
    public interface IReturnVehicleOutputPort : IOutputPortStandard<ReturnVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles messages when the vehicle is not rented.
        /// </summary>
        /// <param name="message">The message to handle.</param>
        void NotRentedHandle(string message);
    }
}
