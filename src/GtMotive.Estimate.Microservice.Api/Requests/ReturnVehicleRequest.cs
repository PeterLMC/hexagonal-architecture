using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public class ReturnVehicleRequest
    {
        [Required]
        public Guid? VehicleId { get; set; }
    }
}
