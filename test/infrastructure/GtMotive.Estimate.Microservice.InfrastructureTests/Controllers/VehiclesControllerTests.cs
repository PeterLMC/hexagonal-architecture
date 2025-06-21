using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Commands.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.Controllers;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Controllers
{
    public class VehiclesControllerTests
    {
        [Fact]
        public async Task CreateValidRequestReturnsCreated()
        {
            var mediator = new Mock<IMediator>();
            var logger = new Mock<IAppLogger<VehiclesController>>();
            var presenter = new CreateVehiclePresenter();
            presenter.StandardHandle(new CreateVehicleOutput(new VehicleId(Guid.NewGuid()), "Bugatti Chiron"));
            mediator.Setup(m => m.Send(It.IsAny<CreateVehicleCommand>(), default)).ReturnsAsync(presenter);
            var controller = new VehiclesController(mediator.Object, logger.Object);

            var request = new CreateVehicleRequest { Model = "Bugatti Chiron", ManufactureDate = DateTime.UtcNow.AddYears(-3) };
            var result = await controller.Create(request);

            Assert.IsType<CreatedResult>(result);
        }
    }
}
