using System;
using GtMotive.Estimate.Microservice.Api.Presenters;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands.RentVehicle
{
    public class RentVehicleCommand(Guid vehicleId, Guid customerId) : IRequest<RentVehiclePresenter>
    {
        public Guid VehicleId { get; } = vehicleId;

        public Guid CustomerId { get; } = customerId;
    }
}
