using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WetherLibrary;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
	private readonly IGetCurrentWeather _getCurrentWeather;

	public WeatherController(IGetCurrentWeather getCurrentWeather)
	{
		_getCurrentWeather = getCurrentWeather;
	}

	[HttpGet("{cityName}")]
	public async Task<IActionResult> GetCurrentTemperature(string cityName, TemperatureUnit unit = TemperatureUnit.Celsius)
	{
		try
		{
			double temperature = await _getCurrentWeather.GetCurrentTempreture(cityName, unit);
			return Ok(temperature);
		}
		catch (Exception ex)
		{
			return BadRequest($"Error occurred while retrieving temperature: {ex.Message}");
		}
	}
}