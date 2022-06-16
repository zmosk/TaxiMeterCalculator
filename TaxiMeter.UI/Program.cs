using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxiMeter.Services.CalculatorService;
using TaxiMeter.Services.Rules;

namespace TaxiMeter.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services
                        .AddLogging()
                        .AddSingleton<ITaxiFareRule, EntryChargeRule>()
                        .AddSingleton<ITaxiFareRule, FastTravelRule>()
                        .AddSingleton<ITaxiFareRule, SlowTravelRule>()
                        .AddSingleton<ITaxiFareRule, PeakRule>()
                        .AddSingleton<ITaxiFareRule, NightTimeRule>()
                        .AddSingleton<ITaxiFareRule, NysLocaleRule>()
                        .AddSingleton<ITaxiFareRule, NotInMotionRule>()
                        .AddSingleton<ICalculatorService, CalculatorService>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
