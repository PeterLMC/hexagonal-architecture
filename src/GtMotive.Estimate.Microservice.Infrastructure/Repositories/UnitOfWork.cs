using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class UnitOfWork(IVehicleRepository vehicleRepository, IAppLogger<UnitOfWork> logger) : IUnitOfWork
    {
        private readonly IAppLogger<UnitOfWork> _logger = logger;

        public IVehicleRepository Vehicles { get; } = vehicleRepository;

        public async Task<int> Save()
        {
            _logger.LogDebug("Saving changes");
            return await Task.FromResult(1);
        }
    }
}
