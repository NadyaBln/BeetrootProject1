using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lesson_24_Sync_HW
{
    class Program
    {
        static async Task Main(string[] args)
        {
            JsonProcessing jsonProcessing = new JsonProcessing();
            HttpClient httpClient = new HttpClient();

            string userCity = jsonProcessing.GetUserCity();
            string filePath = "data1.txt";

            //tried to put all this stuff to separate class and methods - but unsuccessfull :(
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri("https://goweather.herokuapp.com/weather/" + userCity)
            };
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);
            string stringResponse = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(stringResponse);

            Weather.Data weather = JsonConvert.DeserializeObject<Weather.Data>(stringResponse);
            jsonProcessing.PrintWeather(userCity, weather);

            jsonProcessing.JsonToFile(stringResponse, userCity.ToUpper(), filePath);
            jsonProcessing.TextToFile(weather, userCity.ToUpper(), filePath);
        }
    }

    public class Weather
    {
        public class Data
        {
            [JsonProperty("temperature")]
            public string Temperature { get; set; }

            [JsonProperty("wind")]
            public string Wind { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("forecast")]
            public List<Forecast> Forecast { get; set; }
        }
        public class Forecast
        {
            [JsonProperty("day")]
            public int Day { get; set; }

            [JsonProperty("temperature")]
            public string Temperature { get; set; }

            [JsonProperty("wind")]
            public string Wind { get; set; }
        }
    }

    class JsonProcessing
    {
        public string GetUserCity()
        {
            Console.WriteLine("Input city");
            string userCity = Console.ReadLine().ToLower();
            return userCity;
        }

        public void PrintWeather(string userCity, Weather.Data weather)
        {
            Console.WriteLine($"In {userCity.ToUpper()} is {weather.Description} today\nTemperature {weather.Temperature}, Wind {weather.Wind}");
            Console.WriteLine("Forecast for next 3 days:");
            foreach (var i in weather.Forecast)
            {
                Console.WriteLine($"Day {i.Day}\nTemperature: {i.Temperature} Wind: {i.Wind}");
            }
        }

        public void JsonToFile(string stringResponse, string userCity, string filePath)
        {
            string text = userCity + ": " + stringResponse + "\n";
            File.AppendAllText(filePath, text);
        }

        //it was hard!!
        //it works, but I can't understand how it gets data from class Forecast if I pass parameter Weather.Data, not Weather.Forecast
        public void TextToFile(Weather.Data weather, string userCity, string filePath)
        {
            string toFileWeather = string.Empty;
            for (var i = 0; i < 1; i++)
            {
                toFileWeather += $"In {userCity} is {weather.Description} today\nTemperature {weather.Temperature}, Wind {weather.Wind}\n";
            }

            string toFileDefaultText = string.Empty;
            toFileDefaultText += $"Forecast for next 3 days:\n";

            string toFileForecast = string.Empty;
            foreach (var i in weather.Forecast)
            {
                toFileForecast += $"Day {i.Day}\nTemperature: {i.Temperature} Wind: {i.Wind}\n";
            }

            File.AppendAllText(filePath, toFileWeather);
            File.AppendAllText(filePath, toFileDefaultText);
            File.AppendAllText(filePath, toFileForecast);
        }
    }
}
