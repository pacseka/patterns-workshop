using PatternsWorkShop.Services.Visitor;

namespace PatternsWorkShop.Services.State;

public class SunnyState : IWeatherState
{
	private BeachBoy _beachBoy;

	public void Handle()
	{
		_beachBoy.Swim = "Go ahead!";
	}

	public void HandleWeatherChange(string newWeather)
	{
		if (newWeather != "rainy")
		{
			return;
		}

		_beachBoy.ChangeWeather(new RainyState());
	}

	public void SetBeachBoy(BeachBoy beachBoy)
	{
		_beachBoy = beachBoy;
		_beachBoy.SetSunglass("Red");
		_beachBoy.SetRainProtection("None");

		_beachBoy.Accept(new SwimSuitBeachBoyVisitor());
	}
}