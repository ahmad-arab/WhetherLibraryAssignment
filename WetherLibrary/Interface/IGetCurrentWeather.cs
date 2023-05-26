namespace WetherLibrary
{
	public interface IGetCurrentWeather
	{
		Task<double> GetCurrentTempreture(string cityName, TemperatureUnit unit = TemperatureUnit.Celsius);
	}
}