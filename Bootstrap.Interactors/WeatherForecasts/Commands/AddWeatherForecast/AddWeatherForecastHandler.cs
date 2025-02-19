using Bootstrap.Interactors.WeatherForecasts.Queries;
using MediatR;

namespace Bootstrap.Interactors.WeatherForecasts.Commands.AddWeatherForecast
{
    public class AddWeatherForecastHandler : IRequestHandler<AddWeatherForecast, List<WeatherForecast>>
    {
        public Task<List<WeatherForecast>> Handle(AddWeatherForecast request, CancellationToken cancellationToken)
        {
            // Ensure summaries list includes the new weather type
            var summaries = GetWeatherForecastHandler.Summaries.Append(request.Payload.Weather).ToArray();

            var weatherReports = new List<WeatherForecast>();
            var random = new Random(); // Reuse a single Random instance

            foreach (var weather in summaries)
            {
                var report = new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Today),
                    TemperatureC = random.Next(-20, 55), // Generate a temperature
                    Summary = summaries[random.Next(summaries.Length)] // Corrected random selection
                };
                weatherReports.Add(report);
            }

            return Task.FromResult(weatherReports);
        }
    }
}

