using System;

namespace TaxiMeter.Common.Model
{
    public class TaxiRide
    {
        public DateTime StartOfRide { get; set; }

        private DateTime _endOfRide;
        public DateTime EndOfRide { 
            get => _endOfRide == default ? CalculateEndOfRide() : _endOfRide; 
            set => _endOfRide = value; 
        }

        public decimal TotalFare { get; set; }

        public int MinutesOver6Mph { get; set; }

        public decimal MilesUnder6Mph { get; set; }

        /// <summary>
        /// Returns the time traveled under 6 MPH, in minutes.
        /// </summary>
        public int MinutesUnder6Mph
        {
            // In order to calculate the minutes traveled below 6 MPH, we will use the below calculation:
            // t = (distance / speed) * 60
            // Note: We are assuming an avg speed of 3 MPH when calculating time spent below 6 MPH.
            // Also, we have adopted a rounding convention of AwayFromZero.
            get
            {
                var avgMph = 3;
                var minutesUnder6Mph = Math.Round(MilesUnder6Mph / avgMph * 60, MidpointRounding.AwayFromZero);

                return (int)minutesUnder6Mph;
            }
        }

        /// <summary>
        /// Returns the end time of trip, as a local DateTime, based on start time of trip, 
        /// plus the number of minutes traveled above 6 MPH, plus the number of minutes traveled below 6 MPH.
        /// </summary>
        /// <returns></returns>
        public DateTime CalculateEndOfRide()
        {
            var endOfRide = StartOfRide
                .Add(TimeSpan.FromMinutes(MinutesOver6Mph))
                .Add(TimeSpan.FromMinutes(MinutesUnder6Mph));

            return DateTime.SpecifyKind(endOfRide, DateTimeKind.Local);
        }
    }
}
