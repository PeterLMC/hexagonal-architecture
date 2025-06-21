using System;
using System.Threading.Tasks;
using Bogus;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Mock
{
    /// <summary>
    /// Seeds the Vehicles collection with initial data using Bogus.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="VehicleSeed"/> class.
    /// </remarks>
    /// <param name="mongoService">The MongoDB service.</param>
    /// <param name="logger">The logger for the seed process.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public class VehicleSeed(MongoService mongoService, IAppLogger<VehicleSeed> logger)
    {
        private readonly IMongoCollection<VehicleEntity> _vehicles = mongoService.MongoClient.GetDatabase("VehicleRental").GetCollection<VehicleEntity>("Vehicles");
        private readonly IAppLogger<VehicleSeed> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        /// <summary>
        /// Seeds the Vehicles collection with 50 randomly generated vehicles if the collection is empty.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SeedAsync()
        {
            try
            {
                if (await _vehicles.CountDocumentsAsync(Builders<VehicleEntity>.Filter.Empty) > 0)
                {
                    _logger.LogInformation("Vehicles collection already contains data. Skipping seed.");
                    return;
                }

                _logger.LogInformation("Seeding Vehicles collection with 50 vehicles.");

                var faker = new Faker<VehicleEntity>()
                     .CustomInstantiator(f => new VehicleEntity(
                         new VehicleId(Guid.NewGuid()),
                         f.Vehicle.Model(),
                         new ManufactureDate(f.Date.Past(10, DateTime.UtcNow.AddYears(-5)))))
                     .RuleFor(v => v.IsRented, f => false)
                     .RuleFor(v => v.RentedBy, f => null);

                var vehicles = faker.Generate(50);
                await _vehicles.InsertManyAsync(vehicles);

                _logger.LogInformation("Successfully seeded 50 vehicles.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error seeding Vehicles collection: {Message}", ex.Message);
                throw;
            }
        }
    }
}
