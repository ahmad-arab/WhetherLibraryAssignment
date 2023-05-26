using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace WetherLibrary
{
	public static class WhetherAPIExtentions
	{
		public static IServiceCollection AddWeatherAPI(this IServiceCollection serviceCollection, 
			Action<WeatherAPIOptions>? optionsAction = null)
		{
			if (optionsAction == null)
			{
				throw new ArgumentNullException(nameof(optionsAction));
			}
			serviceCollection.Configure(optionsAction);
			serviceCollection.AddSingleton<IGetCurrentWeather, GetCurrentWeather>();
			serviceCollection.AddHttpClient<IGetCurrentWeather, GetCurrentWeather>();
			return serviceCollection;
		}
	}
}
