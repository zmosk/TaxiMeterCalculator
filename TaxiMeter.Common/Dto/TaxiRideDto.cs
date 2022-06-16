using System;

namespace TaxiMeter.Common.Dto
{
    public class TaxiRideDto
    {
        public DateTime StartDateOfRide { get; set; }
        public string StartTimeOfRide { get; set; }
        public decimal MilesUnder6Mph { get; set; }
        public int MinutesOver6Mph { get; set; }
        public decimal TotalFare { get; set; }
    }
}
