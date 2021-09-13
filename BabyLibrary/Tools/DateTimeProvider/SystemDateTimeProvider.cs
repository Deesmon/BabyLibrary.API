using System;

namespace BabyLibrary.Tools.DateTimeProvider
{
    /// <summary>
    /// Implement IDateTimeProvider using statics System.DateTime
    /// </summary>
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time on this
        /// computer, expressed as the local time.
        /// </summary>
        /// <returns></returns>
        public DateTime UtcNow => DateTime.UtcNow;
        /// <summary>
        /// Gets a System.DateTime object that is set to the current date and time on this
        /// computer, expressed as the local time.
        /// </summary>
        /// <returns></returns>
        public DateTime Now => DateTime.Now;
        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <returns></returns>
        public DateTime Today => DateTime.Today;
    }
}
