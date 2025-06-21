using System;
using GtMotive.Estimate.Microservice.Api.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(RentVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);
            var response = new RentVehicleResponse(output.VehicleId.ToGuid(), output.CustomerId.ToGuid());
            ActionResult = new OkObjectResult(response);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void AlreadyRentedHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void CustomerHasRentalHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }
    }
}
