using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents a unique identifier for a vehicle, backed by a <see cref="Guid"/>.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="VehicleId"/> struct with the specified <see cref="Guid"/> value.
    /// </remarks>
    /// <param name="value">The <see cref="Guid"/> value representing the vehicle identifier.</param>
    public readonly struct VehicleId(Guid value)
    {
        /// <summary>
        /// Creates a new <see cref="VehicleId"/> with a randomly generated <see cref="Guid"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="VehicleId"/>.</returns>
        public static VehicleId NewId()
        {
            return new VehicleId(Guid.NewGuid());
        }

        /// <summary>
        /// Returns the string representation of the vehicle identifier.
        /// </summary>
        /// <returns>A string that represents the vehicle identifier.</returns>
        public override string ToString()
        {
            return value.ToString();
        }

        /// <summary>
        /// Returns the underlying <see cref="Guid"/> value of the vehicle identifier.
        /// </summary>
        /// <returns>The <see cref="Guid"/> associated with this <see cref="VehicleId"/>.</returns>
        public Guid ToGuid()
        {
            return value;
        }
    }
}
