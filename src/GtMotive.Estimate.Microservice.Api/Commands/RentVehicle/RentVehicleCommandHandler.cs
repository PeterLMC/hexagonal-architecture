using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands.RentVehicle
{
    public class RentVehicleCommandHandler(IRentVehicleUseCase useCase, RentVehiclePresenter presenter) : IRequestHandler<RentVehicleCommand, RentVehiclePresenter>
    {
        private readonly IRentVehicleUseCase _useCase = useCase;
        private readonly RentVehiclePresenter _presenter = presenter;

        public async Task<RentVehiclePresenter> Handle(RentVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var input = new RentVehicleInput(new VehicleId(request.VehicleId), new CustomerId(request.CustomerId));
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
