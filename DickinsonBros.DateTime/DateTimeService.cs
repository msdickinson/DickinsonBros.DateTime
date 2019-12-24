using System;
using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.DateTime
{
    [ExcludeFromCodeCoverage]
    public class DateTimeService : IDateTimeService
    {
        public System.DateTime GetDateTimeUTC()
        {
            return System.DateTime.UtcNow;
        }
    }
}
