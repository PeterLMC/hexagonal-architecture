using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Customer already has rental Exception.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CustomerAlreadyHasRentalException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAlreadyHasRentalException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CustomerAlreadyHasRentalException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAlreadyHasRentalException"/> class.
        /// </summary>
        public CustomerAlreadyHasRentalException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAlreadyHasRentalException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public CustomerAlreadyHasRentalException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
