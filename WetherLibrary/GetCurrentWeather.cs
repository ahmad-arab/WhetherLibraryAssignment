using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WetherLibrary
{
	public class GetCurrentWeather : IGetCurrentWeather
	{
		private readonly HttpClient _httpClient;
		private readonly WeatherAPIOptions _options;

		public GetCurrentWeather(HttpClient httpClient, IOptions<WeatherAPIOptions> options)
		{
			_httpClient = httpClient;
			_options = options.Value;
		}

		public async Task<double> GetCurrentTempreture(string cityName, TemperatureUnit unit = TemperatureUnit.Celsius)
		{
			if (string.IsNullOrEmpty(_options.ApiKey))
			{
				throw new InvalidOperationException("API key is not provided or is empty.");
			}

			string temperatureUnit = unit == TemperatureUnit.Celsius ? "C" : "F";
			string apiUrl = $"http://api.weatherapi.com/v1/current.json?key={_options.ApiKey}&q={cityName}&aqi=no";

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
				if (!response.IsSuccessStatusCode)
				{
					// Handle API request errors
					throw new HttpRequestException($"Failed to retrieve temperature data. Status code: {response.StatusCode}");
				}

				string responseBody = await response.Content.ReadAsStringAsync();

				var options = new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				};
				var weatherData = JsonSerializer.Deserialize<WeatherApiResponse>(responseBody, options);

				if (weatherData != null && weatherData.Current != null)
				{
					return temperatureUnit switch
					{
						"C" => weatherData.Current.TempC,
						"F" => weatherData.Current.TempF,
						_ => throw new InvalidOperationException("Invalid temperature unit."),
					};
				}
			}
			catch (HttpRequestException ex)
			{
				// Handle HTTP request errors, such as network issues or API unavailability
				Console.WriteLine($"An error occurred while making the API request: {ex.Message}");
			}
			catch (Exception ex)
			{
				// Handle other exceptions, such as JSON parsing errors
				Console.WriteLine($"An error occurred while retrieving the temperature: {ex.Message}");
			}

			return 0; // Return a default value or handle error cases as needed
		}
	}
}
