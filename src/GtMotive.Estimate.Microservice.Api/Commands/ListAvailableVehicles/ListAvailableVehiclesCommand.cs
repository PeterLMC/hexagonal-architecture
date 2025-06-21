using GtMotive.Estimate.Microservice.Api.Presenters;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands.ListAvailableVehicles
{
    public class ListAvailableVehiclesCommand : IRequest<ListAvailableVehiclesPresenter>
    {
    }
}
