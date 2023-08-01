using System;

namespace NeilvynSampleBlueprint.Mobile.Common.Extensions
{
    public static class DateExtensions
    {
        public static bool IsBetween(this TimeSpan? time, TimeSpan timeFrom, TimeSpan timeTo)
        {
            if (time == null)
            {
                return false;
            }
            
            return time >= timeFrom && time <= timeTo;
        }
    }
}