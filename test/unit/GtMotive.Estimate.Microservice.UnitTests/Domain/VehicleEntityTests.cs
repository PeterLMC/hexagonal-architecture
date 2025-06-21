using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Domain
{
    /// <summary>
    /// Contains unit tests for the <see cref="VehicleEntity"/> class, specifically related to renting logic.
    /// </summary>
    public class VehicleEntityTests
    {
        /// <summary>
        /// Verifies that renting a vehicle that is not already rented sets <c>IsRented</c> to <c>true</c>
        /// and assigns the correct <c>RentedBy</c> customer ID.
        /// </summary>
        [Fact]
        public void RentVehicleNotRentedSetsIsRentedAndRentedBy()
        {
            var vehicle = new VehicleEntity(VehicleId.NewId(), "Toyota Corolla", new ManufactureDate(DateTime.UtcNow.AddYears(-6)));
            var customerId = new CustomerId(Guid.NewGuid());

            vehicle.Rent(customerId);

            Assert.True(vehicle.IsRented);
            Assert.Equal(customerId, vehicle.RentedBy);
        }

        /// <summary>
        /// Verifies that attempting to rent a vehicle that is already rented throws a <see cref="VehicleAlreadyRentedException"/>.
        /// </summary>
        [Fact]
        public void RentVehicleAlreadyRentedThrowsException()
        {
            var vehicle = new VehicleEntity(VehicleId.NewId(), "Toyota Corolla", new ManufactureDate(DateTime.UtcNow.AddYears(-6)));
            var customerId = new CustomerId(Guid.NewGuid());
            vehicle.Rent(customerId);

            Assert.Throws<VehicleAlreadyRentedException>(() => vehicle.Rent(customerId));
        }
    }
}
