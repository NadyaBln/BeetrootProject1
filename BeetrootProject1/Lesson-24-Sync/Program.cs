using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_24_Sync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ////diff ways wait task
            ////await - wait for task finish smth
            //await PourACupOfCoffee();

            //var coffee = PourACupOfCoffee();
            //var tea = PourACupOfTea();

            //Task<string> drink = await Task.WhenAny(coffee, tea);
            //Console.WriteLine($"when any: {drink.Result}");

            //await HeatUpSmth();

            //var shower = TakeAShower();
            //var teeth = WashTeeth();

            ////waiting for finish shower and teeth
            //await Task.WhenAll(shower, teeth);

            //TakeAShower().Wait();
            //WashTeeth().GetAwaiter().GetResult();
            //await AddBread().ConfigureAwait(false);
            //await AddJam().ContinueWith(x => Console.WriteLine($"task is finished with status {x.Status}"));
            
            //await ScreamAsync();


            //API
            // 1 - make new httpclient
            var httpClient = new HttpClient();

            // 2 - we sends request to server
            var requestMessage =  new HttpRequestMessage
            {
                //link where we sends message
                RequestUri = new Uri("https://foodish-api.herokuapp.com/api")
            };

            //response 
            var responceMessage = await httpClient.SendAsync(requestMessage);

            //read as string
            var stringResponce = await responceMessage.Content.ReadAsStringAsync();
            //here we get JSON
            Console.WriteLine($"response in JSON format: {stringResponce}");

            // 3 - deserialize resonse from JSON 
            ImgResponce image = JsonConvert.DeserializeObject<ImgResponce>(stringResponce);
            Console.WriteLine($"got img with url {image.Image}");

            // 4 - make new http request
            HttpResponseMessage imageResponce = await httpClient.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri(image.Image)
            });

            //read it as stream 
            await using Stream stream = await imageResponce.Content.ReadAsStreamAsync();

            //write to file
            using (FileStream fileStream = File.Create("food.jpg"))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }

        }

        private static async Task<string> PourACupOfCoffee()
        {
            await Task.Delay(1000);
            return "Make aa coffee";
        }

        private static async Task<string> PourACupOfTea()
        {
            await Task.Delay(2000);
            return "Make aa tea";
        }

        private static async Task HeatUpSmth()
        {
            await Task.Delay(1000);
            Console.WriteLine("Heat up smth");
        }

        private static async Task TakeAShower()
        {
            await Task.Delay(1000);
            Console.WriteLine("Take A Shower");
        }

        private static async Task WashTeeth()
        {
            await Task.Delay(1000);
            Console.WriteLine("Wash Teeth");
        }

        private static async Task AddBread()
        {
            await Task.Delay(1000);
            Console.WriteLine("Add Bread");
        }

        private static async Task AddJam()
        {
            await Task.Delay(1000);
            Console.WriteLine("Add Jam");
        }

        private static void Scream()
        {
            Console.WriteLine("AAAAAAAAAAA");
        }

        private static Task ScreamAsync()
        {
            return Task.Run(() => Scream());
        }

        //API
        private class ImgResponce
        {
            public string Image { get; set; }
        }
    }
}
