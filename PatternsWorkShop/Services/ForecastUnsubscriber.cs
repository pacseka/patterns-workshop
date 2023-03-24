namespace PatternsWorkShop.Services;

public class ForecastUnsubscriber<TWeatherForecast> : IDisposable
{
	private readonly List<IObserver<TWeatherForecast>> _forecastObservers;
	private readonly IObserver<TWeatherForecast> _forecastObserver;

	public ForecastUnsubscriber(List<IObserver<TWeatherForecast>> observers, IObserver<TWeatherForecast> observer)
	{
		_forecastObservers = observers;
		_forecastObserver = observer;

	}

	public void Dispose()
	{
		_forecastObservers.Remove(_forecastObserver);
	}
}