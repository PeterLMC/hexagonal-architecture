using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GtMotive.Estimate.Microservice.Infrastructure.Serializers
{
    public class ManufactureDateSerializer : SerializerBase<ManufactureDate>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, ManufactureDate value)
        {
            ArgumentNullException.ThrowIfNull(context);
            var dateTime = value.ToDateTime();
            var millisecondsSinceEpoch = (long)(dateTime.ToUniversalTime() - DateTime.UnixEpoch).TotalMilliseconds;
            context.Writer.WriteDateTime(millisecondsSinceEpoch);
        }

        public override ManufactureDate Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (context.Reader.CurrentBsonType != BsonType.DateTime)
            {
                throw new BsonSerializationException($"Expected a DateTime for ManufactureDate, but found {context.Reader.CurrentBsonType}.");
            }

            var ticks = context.Reader.ReadDateTime();
            var dateTimeValue = DateTime.UnixEpoch.AddMilliseconds(ticks);
            return new ManufactureDate(DateTime.SpecifyKind(dateTimeValue, DateTimeKind.Utc));
        }
    }
}
