using System;

namespace GtMotive.Estimate.Microservice.Api.Responses
{
    public class RentVehicleResponse(Guid vehicleId, Guid customerId)
    {
        public Guid VehicleId { get; } = vehicleId;

        public Guid CustomerId { get; } = customerId;
    }
}
