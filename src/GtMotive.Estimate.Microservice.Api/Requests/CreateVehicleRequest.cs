using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public class CreateVehicleRequest
    {
        [Required]
        public string Model { get; set; }

        [Required]
        public DateTime? ManufactureDate { get; set; }
    }
}
