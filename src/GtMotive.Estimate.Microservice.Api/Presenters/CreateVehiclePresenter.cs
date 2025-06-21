using System;
using GtMotive.Estimate.Microservice.Api.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class CreateVehiclePresenter : IWebApiPresenter, ICreateVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(CreateVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);
            var response = new CreateVehicleResponse(output.VehicleId.ToGuid(), output.Model);
            ActionResult = new CreatedResult($"/api/vehicles/{response.VehicleId}", response);
        }

        public void ErrorHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }
    }
}
