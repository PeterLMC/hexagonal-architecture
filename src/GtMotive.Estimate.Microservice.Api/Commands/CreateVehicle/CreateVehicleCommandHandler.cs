using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands.CreateVehicle
{
    public class CreateVehicleCommandHandler(ICreateVehicleUseCase useCase, CreateVehiclePresenter presenter) : IRequestHandler<CreateVehicleCommand, CreateVehiclePresenter>
    {
        private readonly ICreateVehicleUseCase _useCase = useCase;
        private readonly CreateVehiclePresenter _presenter = presenter;

        public async Task<CreateVehiclePresenter> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var input = new CreateVehicleInput(request.Model, request.ManufactureDate);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
