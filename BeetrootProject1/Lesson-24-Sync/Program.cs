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
            //await PourACupOfCoffee();
            //var coffee =  PourACupOfCoffee();
            //var tea =  PourACupOfTea();

            //Task<string> drink = await Task.WhenAny(coffee, tea);
            //Console.WriteLine(drink.Result);

            //await HeatUpSmth();

            //var shower = TakeAShower();
            //var teeth = WashTeeth();

            ////waiting for finish
            //await Task.WhenAll(shower, teeth);

            //TakeAShower().Wait();
            //WashTeeth().GetAwaiter().GetResult();
            //await AddBread();
            //await AddJam().ContinueWith(x => Console.WriteLine($"task is finished with status {x.Status}"));
            //await ScreamAsync();


            var httpClient = new HttpClient();
            var requestMessage =  new HttpRequestMessage
            {
                RequestUri = new Uri("https://foodish-api.herokuapp.com/api")
            };
            var responceMessage = await httpClient.SendAsync(requestMessage);
            var stringResponce = await responceMessage.Content.ReadAsStringAsync();
            Console.WriteLine(stringResponce);


            var image = JsonConvert.DeserializeObject<ImgResponce>(stringResponce);

            Console.WriteLine(stringResponce);
            Console.WriteLine($"got img with url {image.Image}");

            var imageResponce = await httpClient.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri(image.Image)
            });

            await using var stream = await imageResponce.Content.ReadAsStreamAsync();

            //wrte to file
            using (var fileStream = File.Create("food.jpg"))
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
            await Task.Delay(1000);
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

        private class ImgResponce
        {
            public string Image { get; set; }
        }
    }
}
