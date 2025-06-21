using System;
using GtMotive.Estimate.Microservice.Api.Presenters;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands.CreateVehicle
{
    public class CreateVehicleCommand(string model, DateTime manufactureDate) : IRequest<CreateVehiclePresenter>
    {
        public string Model { get; } = model;

        public DateTime ManufactureDate { get; } = manufactureDate;
    }
}
