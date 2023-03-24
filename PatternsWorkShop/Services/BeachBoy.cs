using PatternsWorkShop.Services.State;
using PatternsWorkShop.Services.Visitor;

namespace PatternsWorkShop.Services;

public class BeachBoy : IBeachgoer
{
	public static BeachBoy CreateSunny() => new(new SunnyState());

	public static BeachBoy CreateRainy() => new(new RainyState());

	private IWeatherState _weatherState;

	public string SunGlass { get; private set; } = "None";

	public string RainProtection { get; private set; } = "None";

	public string Swim { get; set; } = "Undefined";

	public string SwimSuite { get; set; } = "None";

	public string BeachBody { get; set; } = "Fat";

	private BeachBoy(IWeatherState weatherState)
	{
		_weatherState = weatherState;
		_weatherState.SetBeachBoy(this);
		_weatherState.Handle();
	}

	public void SetSunglass(string color)
	{
		SunGlass = color;
	}

	public void SetRainProtection(string rainProtection)
	{
		RainProtection = rainProtection;
	}

	public void ChangeWeather(IWeatherState weatherState)
	{
		_weatherState = weatherState;
		_weatherState.SetBeachBoy(this);
	}

	public string Swimming()
	{
		_weatherState.Handle();
		return Swim;
	}

	public void Accept(IBeachVisitor visitor)
	{
		visitor.VisitBeachgoer(this);
	}
}