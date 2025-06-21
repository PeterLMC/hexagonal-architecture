using System;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents the manufacturing date of a vehicle, with a maximum allowed age of 5 years.
    /// </summary>
    /// <param name="value">The manufacturing date of the vehicle.</param>
    /// <exception cref="DomainException">Thrown when the manufacturing date is newer than 5 years from the current date.</exception>
    public readonly struct ManufactureDate(DateTime value)
    {
        /// <summary>
        /// Gets the manufacturing date of the vehicle.
        /// </summary>
        public DateTime Value { get; } = value > DateTime.UtcNow.AddYears(-5)
            ? throw new DomainException("Vehicle manufacture date must not be newer than 5 years.")
            : value;

        /// <summary>
        /// Returns the manufacturing date as a formatted string ("yyyy-MM-dd").
        /// </summary>
        /// <returns>A string representation of the manufacturing date.</returns>
        public override string ToString() => Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

        /// <summary>
        /// Returns the underlying <see cref="DateTime"/> value.
        /// </summary>
        /// <returns>The manufacturing date as a <see cref="DateTime"/>.</returns>
        public DateTime ToDateTime() => Value;
    }
}
