using System;

namespace Travel.Application.Common.Interfaces
{
    /// <summary>
    /// The following code is a contract of the DateTime service.
    /// </summary>
    public interface IDateTime
    {
        DateTime NowUtc { get; }
    }
}
