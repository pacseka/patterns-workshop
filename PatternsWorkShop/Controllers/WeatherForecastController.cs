using Microsoft.AspNetCore.Mvc;
using PatternsWorkShop.Services;
using PatternsWorkShop.Services.Visitor;

namespace PatternsWorkShop.Controllers;

[ApiController]
[Route("weatherforecast")]
public class WeatherForecastController : ControllerBase
{
	private static readonly string[] _summaries = {
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	[HttpGet(Name = "GetWeatherForecast")]
	public IEnumerable<WeatherForecast> Get()
	{
		return Enumerable.Range(1, 5).Select(_ => new WeatherForecast
		{
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = _summaries[Random.Shared.Next(_summaries.Length)]
		})
			.ToArray();
	}

	[HttpPut(Name = "WeatherForecastUpdate")]
	public ActionResult CreateWeatherForecast([FromBody] WeatherForecast forecast)
	{
		var provider = new ForecastProvider();
		var glassObserver = new SunglassCleaner();

		provider.Subscribe(glassObserver);

		var umbrellaObserver = new UmbrellaOpener();

		provider.Subscribe(umbrellaObserver);

		provider.WeatherForecastUpdated(forecast);


		var beachBoy = glassObserver.BeachBoy ?? umbrellaObserver.BeachBoy;

		var beachGirl = new BeachGirl();

		beachGirl.Accept(new SwimSuitBeachGirlVisitor());
		beachGirl.Accept(new BeachBodyGirlVisitor());


		return Ok(
			$"Napszemüveg tiszta: {glassObserver.IsSunglassClean}. Esernyő nyitva:{umbrellaObserver.IsUmbrellaOpened}. Úszás: {beachBoy.Swimming()}. Úszó dress lány:{beachGirl.SwimSuite}, fiú: {beachBoy.SwimSuite}. Beach Body Girl:{beachGirl.BeachBody}");
	}
}