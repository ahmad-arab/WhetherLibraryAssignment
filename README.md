# WhetherLibraryAssignment
This repository contains two projects: 
<li>WeatherLibrary: It is a class library built with .NET Core 6, it can be used in any .NET project
&nbsp;to get the current temprature of any city in the world. it brings weather information from weatherapi.com
<li>UseCase: A simple API that uses WeatherLibrary it has one controller which has one method which takes
    &nbsp;a city name as a parameter, and it has an optional parameter which specifies if i want the result in
    &nbsp;Celsius or Fahrenheit. 0 = Celsius, 1 = Fahrenheit.
     
# how to use:
 <li> Clone the repo to your local computer
<li> Change the ApiKey in program.cs in UseCase project
   <li> Set the UseCase project as the startup project
     <li> Play with it as you want
