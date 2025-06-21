using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public class RentVehicleRequest
    {
        [Required]
        public Guid? VehicleId { get; set; }

        [Required]
        public Guid? CustomerId { get; set; }
    }
}
