using System;

namespace BabyLibrary.Tools.DateTimeProvider
{
    /// <summary>
    /// DateTimeProvider interface, enable unit testing date related code.
    /// </summary>
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
        DateTime Now { get; }
        DateTime Today { get; }
    }
}
