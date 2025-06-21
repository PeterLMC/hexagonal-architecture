using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Interface for the list available vehicles use case.
    /// </summary>
    public interface IListAvailableVehiclesUseCase
    {
        /// <summary>
        /// Executes the list available vehicles operation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Execute();
    }
}
