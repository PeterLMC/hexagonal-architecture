using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands.ListAvailableVehicles
{
    public class ListAvailableVehiclesCommandHandler(IListAvailableVehiclesUseCase useCase, ListAvailableVehiclesPresenter presenter) : IRequestHandler<ListAvailableVehiclesCommand, ListAvailableVehiclesPresenter>
    {
        private readonly IListAvailableVehiclesUseCase _useCase = useCase;
        private readonly ListAvailableVehiclesPresenter _presenter = presenter;

        public async Task<ListAvailableVehiclesPresenter> Handle(ListAvailableVehiclesCommand request, CancellationToken cancellationToken)
        {
            await _useCase.Execute();
            return _presenter;
        }
    }
}
