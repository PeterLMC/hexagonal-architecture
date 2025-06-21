using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GtMotive.Estimate.Microservice.Infrastructure.Serializers
{
    public class VehicleIdSerializer : SerializerBase<VehicleId>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, VehicleId value)
        {
            ArgumentNullException.ThrowIfNull(context);
            context.Writer.WriteString(value.ToGuid().ToString());
        }

        public override VehicleId Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (context.Reader.CurrentBsonType != BsonType.String)
            {
                throw new BsonSerializationException($"Expected a string for VehicleId, but found {context.Reader.CurrentBsonType}.");
            }

            var stringValue = context.Reader.ReadString();
            return new VehicleId(Guid.Parse(stringValue));
        }
    }
}
