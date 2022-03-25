using System;
using Travel.Application.Common.Interfaces;

namespace Travel.Shared.Services
{
    /// <summary>
    /// The preceding code is an implementation of IDateTime. It only returns DateTime.
    /// UtcNow.
    /// </summary>
    public class DateTimeService : IDateTime
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}