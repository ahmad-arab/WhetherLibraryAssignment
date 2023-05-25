using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			return serviceCollection.AddSingleton<IGetCurrentWeather, GetCurrentWeather>();
		}
	}
}
