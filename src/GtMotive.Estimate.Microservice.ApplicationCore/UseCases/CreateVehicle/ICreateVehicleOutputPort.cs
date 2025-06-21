namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Output port for the create vehicle use case.
    /// </summary>
    public interface ICreateVehicleOutputPort : IOutputPortStandard<CreateVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles error messages for the create vehicle operation.
        /// </summary>
        /// <param name="message">The error message to handle.</param>
        void ErrorHandle(string message);
    }
}
