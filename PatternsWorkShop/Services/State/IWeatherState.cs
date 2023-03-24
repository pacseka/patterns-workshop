namespace PatternsWorkShop.Services.State;

public interface IWeatherState
{
	public void Handle();

	public void HandleWeatherChange(string newWeather);

	public void SetBeachBoy(BeachBoy beachBoy);
}