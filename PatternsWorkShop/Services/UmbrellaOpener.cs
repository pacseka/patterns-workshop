namespace PatternsWorkShop.Services;

public class UmbrellaOpener : IObserver<WeatherForecast>
{
	public WeatherForecast WeatherForecast { get; private set; }

	public BeachBoy BeachBoy { get; private set; }

	private IDisposable _unsubscriber;

	public bool IsUmbrellaOpened { get; private set; }


	public virtual void Subscribe(ForecastProvider provider)
	{
		_unsubscriber = provider.Subscribe(this);
	}

	public virtual void Unsubscribe()
	{
		_unsubscriber.Dispose();
	}

	public void OnCompleted()
	{
		throw new NotImplementedException();
	}

	public void OnError(Exception error)
	{
		throw new NotImplementedException();
	}

	public void OnNext(WeatherForecast value)
	{
		WeatherForecast = value;

		if (WeatherForecast.Summary != "rainy")
		{
			return;
		}

		IsUmbrellaOpened = true;

		BeachBoy = BeachBoy.CreateRainy();
	}
}