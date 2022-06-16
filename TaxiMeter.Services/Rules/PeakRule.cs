using System;
using TaxiMeter.Common.Model;

namespace TaxiMeter.Services.Rules
{
    public class PeakRule : ITaxiFareRule
    {
        public decimal CalculateCharge(TaxiRide taxiRide)
        {
            var peakSurcharge = 1m;

            // Loop from start of ride, hour by hour, until endOfRide, checking if time is within Peak period
            var timeOfRide = taxiRide.StartOfRide;            
            while (timeOfRide <= taxiRide.EndOfRide)
            {
                if (IsDuringPeak(timeOfRide))
                    return peakSurcharge;

                var timeleftUntilEnd = taxiRide.EndOfRide - timeOfRide;

                // break out of loop once timeOfRide is equal to endOfRide
                if (timeleftUntilEnd.TotalMinutes == 0)
                    break;
                
                timeOfRide = timeleftUntilEnd.TotalHours < 1
                    ? timeOfRide.AddMinutes(timeleftUntilEnd.TotalMinutes)
                    : timeOfRide.AddHours(1);
            }

            return 0m;
        }

        private bool IsDuringPeak(DateTime timeOfRide)
        {
            if (IsWeekend(timeOfRide))
                return false;

            var beginPeakPeriod = timeOfRide.Date.AddHours(16);   // 4PM
            var endPeakPeriod = timeOfRide.Date.AddHours(20);     // 8PM

            return timeOfRide >= beginPeakPeriod && timeOfRide < endPeakPeriod;
        }

        protected bool IsWeekend(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday ||
                    dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public string GetChargeType()
        {
            return "Peak Hour Charge";
        }
    }
}