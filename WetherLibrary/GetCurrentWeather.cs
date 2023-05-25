using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WetherLibrary
{
	public class GetCurrentWeather : IGetCurrentWeather
	{
		private readonly WeatherAPIOptions _options;

		public GetCurrentWeather(IOptions<WeatherAPIOptions> options)
		{
			_options = options.Value;
		}

		public decimal GetCurrentTempreture(string cityName, bool isCelsius = true)
		{
			throw new NotImplementedException();
		}
	}
}
