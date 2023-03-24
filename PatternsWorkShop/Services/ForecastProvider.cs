namespace PatternsWorkShop.Services;

public class ForecastProvider : IObservable<WeatherForecast>
{
	private readonly List<IObserver<WeatherForecast>> _forecastsObservers;

	public ForecastProvider()
	{
		_forecastsObservers = new List<IObserver<WeatherForecast>>();
	}

	public IDisposable Subscribe(IObserver<WeatherForecast> observer)
	{
		if (!_forecastsObservers.Contains(observer))
		{
			_forecastsObservers.Add(observer);
		}

		return new ForecastUnsubscriber<WeatherForecast>(_forecastsObservers, observer);
	}

	public void WeatherForecastUpdated(WeatherForecast forecast)
	{
		foreach (var observer in _forecastsObservers)
		{
			observer.OnNext(forecast);
		}
	}
}