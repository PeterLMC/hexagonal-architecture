using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Vehicle already rented Exception.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class VehicleAlreadyRentedException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public VehicleAlreadyRentedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        public VehicleAlreadyRentedException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public VehicleAlreadyRentedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
