namespace PatternsWorkShop.Services.State;

public class RainyState : IWeatherState
{
	private BeachBoy _beachBoy;

	public void Handle()
	{
		_beachBoy.Swim = "No way";
	}

	public void HandleWeatherChange(string newWeather)
	{
		if (newWeather != "sunny")
		{
			return;
		}

		_beachBoy.ChangeWeather(new SunnyState());
	}

	public void SetBeachBoy(BeachBoy beachBoy)
	{
		_beachBoy = beachBoy;
		_beachBoy.SetSunglass("None");
		_beachBoy.SetRainProtection("Umbrella");
	}
}