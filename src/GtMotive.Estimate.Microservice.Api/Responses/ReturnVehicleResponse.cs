using System;

namespace GtMotive.Estimate.Microservice.Api.Responses
{
    public class ReturnVehicleResponse(Guid vehicleId)
    {
        public Guid VehicleId { get; } = vehicleId;
    }
}
