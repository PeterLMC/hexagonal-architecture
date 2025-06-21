using System;
using GtMotive.Estimate.Microservice.Api.Presenters;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands.ReturnVehicle
{
    public class ReturnVehicleCommand(Guid vehicleId) : IRequest<ReturnVehiclePresenter>
    {
        public Guid VehicleId { get; } = vehicleId;
    }
}
