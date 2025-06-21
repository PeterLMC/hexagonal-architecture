using System;

namespace GtMotive.Estimate.Microservice.Api.Responses
{
    public class CreateVehicleResponse(Guid vehicleId, string model)
    {
        public Guid VehicleId { get; } = vehicleId;

        public string Model { get; } = model;
    }
}
