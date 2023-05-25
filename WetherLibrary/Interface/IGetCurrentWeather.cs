namespace WetherLibrary
{
	public interface IGetCurrentWeather
	{
		decimal GetCurrentTempreture(string cityName, bool isCelsius = true);
	}
}