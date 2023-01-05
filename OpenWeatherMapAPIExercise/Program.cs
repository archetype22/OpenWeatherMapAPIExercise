using Newtonsoft.Json.Linq;


var client = new HttpClient();

var apiKey = "7625cf0e25d76a00bf6a6511055c94b4";

Console.WriteLine("In which city do you wish to check the current weather?");
var cityName = Console.ReadLine();

var openWeatherMapURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";
string weatherCurrent = client.GetStringAsync(openWeatherMapURL).Result;
JObject weatherObject = JObject.Parse(weatherCurrent);

Console.WriteLine($"The current weather conditions in {cityName}: ");
Console.WriteLine(weatherObject);
Console.WriteLine();
Console.WriteLine($"It is {weatherObject["main"]["temp"]} degrees Fahrenheit in {cityName}, currently.");
Console.WriteLine();
var weatherObjectConverted = Convert.ToInt32((weatherObject["main"]["temp"]));
if (weatherObjectConverted < 60) 
{
    Console.WriteLine("Consider wearing a jacket.");
}