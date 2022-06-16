using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TaxiMeter.Common.Dto;
using TaxiMeter.Common.Model;
using TaxiMeter.Services.CalculatorService;

namespace TaxiMeter.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxiFareController : ControllerBase
    {
        private readonly ILogger<TaxiFareController> _logger;
        private readonly ICalculatorService _calculatorService;

        public TaxiFareController(ILogger<TaxiFareController> logger, ICalculatorService calculatorSevice)
        {
            _logger = logger;
            _calculatorService = calculatorSevice;
        }

        [HttpPost]
        public decimal CalculateTaxiFare(TaxiRideDto taxiRideDto)
        {
            try
            {
                // Combine startDate and startTime into one property. Would use automapper in large-scale application.
                var taxiRide = new TaxiRide
                {
                    StartOfRide = taxiRideDto.StartDateOfRide.Add(TimeSpan.Parse(taxiRideDto.StartTimeOfRide)),
                    MilesUnder6Mph = taxiRideDto.MilesUnder6Mph,
                    MinutesOver6Mph = taxiRideDto.MinutesOver6Mph
                };

                // Call service
                var fare = _calculatorService.CalculateFare(taxiRide);
                return fare;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An error occurred in {nameof(CalculateTaxiFare)}");

                throw new Exception("Error calculating Taxi Fare");
            }
        }
    }
}
