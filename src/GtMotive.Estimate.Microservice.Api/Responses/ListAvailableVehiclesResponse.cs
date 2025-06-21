using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;

namespace GtMotive.Estimate.Microservice.Api.Responses
{
    public class ListAvailableVehiclesResponse(IEnumerable<VehicleDto> vehicles)
    {
        public IEnumerable<VehicleDto> Vehicles { get; } = vehicles;
    }
}
