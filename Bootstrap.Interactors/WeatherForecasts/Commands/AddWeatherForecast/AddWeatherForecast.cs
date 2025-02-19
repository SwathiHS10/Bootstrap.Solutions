using Bootstrap.Interactors.WeatherForecasts.Queries;
using MediatR;

namespace Bootstrap.Interactors.WeatherForecasts.Commands.AddWeatherForecast
{
    public class AddWeatherForecast: IRequest<List<WeatherForecast>>
    {
        public AddWeatherForecastRequest Payload { get; set; }
    }
}
