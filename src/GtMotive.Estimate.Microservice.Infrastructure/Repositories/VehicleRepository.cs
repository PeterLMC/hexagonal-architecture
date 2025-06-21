using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using GtMotive.Estimate.Microservice.Infrastructure.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<VehicleEntity> _vehicles;
        private readonly IAppLogger<VehicleRepository> _logger;

        public VehicleRepository(MongoService mongoService, IAppLogger<VehicleRepository> logger)
        {
            ArgumentNullException.ThrowIfNull(mongoService);
            _vehicles = mongoService.MongoClient.GetDatabase("VehicleRental").GetCollection<VehicleEntity>("Vehicles");
            _logger = logger;

            // Register BSON mappings
            if (!BsonClassMap.IsClassMapRegistered(typeof(VehicleEntity)))
            {
                BsonClassMap.RegisterClassMap<VehicleEntity>(cm =>
                {
                    cm.AutoMap();
                    cm.MapMember(v => v.Id).SetSerializer(new VehicleIdSerializer());
                    cm.MapMember(v => v.RentedBy).SetSerializer(new CustomerIdSerializer()).SetDefaultValue(null);
                    cm.MapMember(v => v.ManufactureDate).SetSerializer(new ManufactureDateSerializer());
                });
            }
        }

        public async Task Add(IVehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);
            _logger.LogDebug("Adding vehicle with Id: {VehicleId}", vehicle.Id);
            await _vehicles.InsertOneAsync((VehicleEntity)vehicle);
        }

        public async Task<IVehicle> GetBy(VehicleId vehicleId)
        {
            _logger.LogDebug("Retrieving vehicle with Id: {VehicleId}", vehicleId);
            return await _vehicles.Find(v => v.Id.Equals(vehicleId)).FirstOrDefaultAsync();
        }

        public async Task Update(IVehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);
            _logger.LogDebug("Updating vehicle with Id: {VehicleId}", vehicle.Id);
            await _vehicles.ReplaceOneAsync(v => v.Id.Equals(vehicle.Id), (VehicleEntity)vehicle);
        }

        public async Task<List<IVehicle>> GetAvailableVehicles()
        {
            _logger.LogDebug("Retrieving available vehicles");
            var vehicles = await _vehicles.Find(v => !v.IsRented).ToListAsync();
#pragma warning disable IDE0305 // Simplificar la inicialización de la recopilación
            return vehicles.Cast<IVehicle>().ToList();
#pragma warning restore IDE0305 // Simplificar la inicialización de la recopilación
        }

        public async Task<bool> HasActiveRental(CustomerId customerId)
        {
            _logger.LogDebug("Checking active rental for CustomerId: {CustomerId}", customerId);
            return await _vehicles.Find(v => v.IsRented && v.RentedBy.Equals(customerId)).AnyAsync();
        }
    }
}
