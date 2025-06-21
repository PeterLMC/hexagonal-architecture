using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Commands.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.Commands.ListAvailableVehicles;
using GtMotive.Estimate.Microservice.Api.Commands.RentVehicle;
using GtMotive.Estimate.Microservice.Api.Commands.ReturnVehicle;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController(IMediator mediator, IAppLogger<VehiclesController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IAppLogger<VehiclesController> _logger = logger;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody][Required] CreateVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            _logger.LogDebug("Entering Create. Request: {@request}", request);
            var command = new CreateVehicleCommand(request.Model, request.ManufactureDate.Value);
            var presenter = await _mediator.Send(command);
            return presenter.ActionResult;
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            _logger.LogDebug("Entering GetAvailable");
            var command = new ListAvailableVehiclesCommand();
            var presenter = await _mediator.Send(command);
            return presenter.ActionResult;
        }

        [HttpPost("rent")]
        public async Task<IActionResult> Rent([FromBody][Required] RentVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            _logger.LogDebug("Entering Rent. Request: {@request}", request);
            var command = new RentVehicleCommand(request.VehicleId.Value, request.CustomerId.Value);
            var presenter = await _mediator.Send(command);
            return presenter.ActionResult;
        }

        [HttpPost("return")]
        public async Task<IActionResult> Return([FromBody][Required] ReturnVehicleRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            _logger.LogDebug("Entering Return. Request: {@request}", request);
            var command = new ReturnVehicleCommand(request.VehicleId.Value);
            var presenter = await _mediator.Send(command);
            return presenter.ActionResult;
        }
    }
}
