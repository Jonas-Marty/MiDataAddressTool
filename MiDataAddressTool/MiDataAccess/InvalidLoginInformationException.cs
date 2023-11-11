using System;

namespace MiDataAccess;

/// <summary>
/// Represents an 
/// </summary>
public class InvalidLoginInformationException : Exception
{
    private const string DefaultMessage = "Token oder ID falsch.";

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidLoginInformationException"/> class with the default message.
    /// </summary>
    public InvalidLoginInformationException()
        : this(DefaultMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidLoginInformationException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidLoginInformationException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidLoginInformationException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="inner">The inner exception.</param>
    public InvalidLoginInformationException(string message, Exception inner)
        : base(message, inner)
    {
    }
}