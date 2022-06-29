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
            //Use any API to request data and return it to the user in user readable form
            //Extra:
            //Use several APIs to request data, e.g.user inputs data, application requests it’s geolocation and returns
            //weather in current geolocation

            var httpClient = new HttpClient();
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri("https://goweather.herokuapp.com/weather/Kyiv")
            };

            var responceMessage = await httpClient.SendAsync(requestMessage);
            var stringResponce = await responceMessage.Content.ReadAsStringAsync();

            Console.WriteLine($"response in JSON format: {stringResponce}");

            // deserialize resonse from JSON 
            //var source = stringResponce;
            //var parsed = JsonConvert.DeserializeObject<Dictionary<string, Data>>(stringResponce);
            
            var json = System.IO.File.ReadAllText("data1.json");
            Data[] courses = JsonConvert.DeserializeObject<Data[]>(json);

            Console.WriteLine(courses);

            //foreach (var data in courses)
            //{
            //    Console.WriteLine($"Key: {data.Key}");
            //    Console.WriteLine($"Temperature: {data.Temperature} Wind: {data.Wind} Description: {data.Description} ");
            //}



            //APIResponse image = JsonConvert.DeserializeObject<APIResponse>(stringResponce);
            //Console.WriteLine($"got img with url {image.Response}");

            //HttpResponseMessage imageResponce = await httpClient.SendAsync(new HttpRequestMessage
            //{
            //    RequestUri = new Uri(stringResponce)
            //});

            //read it as stream
            //await using Stream stream = await imageResponce.Content.ReadAsStreamAsync();

            //save
            //using (FileStream fileStream = File.Create("weatherKyiv.txt"))
            //{
            //    stream.Seek(0, SeekOrigin.Begin);
            //    stream.CopyTo(fileStream);
            //}
        }

        //private class APIResponse
        //{
        //    public string Response { get; set; }
        //}
        public class Data
        {
            public string Temperature { get; set; }
            public string Wind { get; set; }
            public string Description { get; set; }
            public object Key { get; internal set; }
            public object Value { get; internal set; }
        }

    }
}
