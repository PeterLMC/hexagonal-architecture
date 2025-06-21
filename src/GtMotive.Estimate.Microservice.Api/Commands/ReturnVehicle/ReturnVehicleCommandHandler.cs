using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands.ReturnVehicle
{
    public class ReturnVehicleCommandHandler(IReturnVehicleUseCase useCase, ReturnVehiclePresenter presenter) : IRequestHandler<ReturnVehicleCommand, ReturnVehiclePresenter>
    {
        private readonly IReturnVehicleUseCase _useCase = useCase;
        private readonly ReturnVehiclePresenter _presenter = presenter;

        public async Task<ReturnVehiclePresenter> Handle(ReturnVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var input = new ReturnVehicleInput(new VehicleId(request.VehicleId));
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
