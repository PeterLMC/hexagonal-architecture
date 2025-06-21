using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GtMotive.Estimate.Microservice.Infrastructure.Serializers
{
    public class CustomerIdSerializer : SerializerBase<CustomerId?>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, CustomerId? value)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (value.HasValue)
            {
                context.Writer.WriteString(value.Value.ToGuid().ToString());
            }
            else
            {
                context.Writer.WriteNull();
            }
        }

        public override CustomerId? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (context.Reader.CurrentBsonType == BsonType.Null)
            {
                context.Reader.ReadNull();
                return null;
            }

            return new CustomerId(Guid.Parse(context.Reader.ReadString()));
        }
    }
}
