using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents a unique identifier for a customer, backed by a <see cref="Guid"/>.
    /// </summary>
    public readonly struct CustomerId(Guid value)
    {
        /// <summary>
        /// Returns the string representation of the customer identifier.
        /// </summary>
        /// <returns>A string that represents the customer identifier.</returns>
        public override string ToString()
        {
            return value.ToString();
        }

        /// <summary>
        /// Returns the underlying <see cref="Guid"/> value of the customer identifier.
        /// </summary>
        /// <returns>The <see cref="Guid"/> associated with this <see cref="CustomerId"/>.</returns>
        public Guid ToGuid()
        {
            return value;
        }
    }
}
