using System;
using System.Net.Http;

namespace lesson_14_AbstrClassAndInterfaces_CW
{
    class Program14
    {
        public static void Main(string[] args)
        {
            // we can't do instance of abstract class
            // Animal animal = new Animal();
            Animal animal = new Cat();
            animal.Noise(new ConsoleNotification());
            animal.Noise(new HttpNotification());
        }

        // create this interfase to implement Strategy pattern
        // Interfase - is description of what your class can do. 
        // So in Class which implements interface INotification will be void method Notify 

        // we can inherit several interfaces
        public interface INotification
        {
            void Notify(string message);

            //can't add realization here.
        }

        // realization of Notification by Console. 
        // INotification interface inherits
        // we should implement all methods from interface
        public class ConsoleNotification : INotification
        {
            public void Notify(string message)
            {
                Console.WriteLine("Cat said meoww");
            }
        }

        // realization of Notification by HTTP. 
        public class HttpNotification : INotification
        {
            public void Notify(string message)
            {
                Console.WriteLine("Via Http - Cat said meoww");
            }
        }
        public abstract class Animal
        {
            // absract method is method which doesn't have any realisation
            // we can't create instances on abstract classes. because there is no behaviour, details.
            // this is ex of abstraction
            // NoiseType noiseType = NoiseType.Console -> paramether by default

            //we can inherit only 1 abstract class
            public abstract void Noise(INotification notification);

            //public void ExMethod()
            //{
            //    can add realization here. 
            //}
        }

        public class Cat : Animal
        {
            // NoiseType noiseType = NoiseType.Console -> means: default value - console

            // Open-Close principle is violated in this class.
            // because in case we want to add/edit any connection tunnel - we should edit this class.
            // better to use pattern Strategy here

            // Not good method. Replace it with better implementation of OpenCloe principle

                //public override void Noise(NoiseType noiseType = NoiseType.Console)
                //{
                    //if (noiseType == NoiseType.Console)
                    //{
                    //    Console.WriteLine("Cat said Meow!");
                    //}
                    //else if (noiseType == NoiseType.Http)
                    //{
                    //    this.SendRequest();
                    //}
                    //else
                    //{
                    //    //sending by smtp
                    //}
                //}

            // due to this realization we implement Open-close principle
            public override void Noise (INotification notification)
            {
                notification.Notify(string.Empty);
            }

            // don't need this method now. As we have interface
            ////variant of displaying Animal sound
            //private void SendRequest()
            //{
            //    var httpClient = new HttpClient();
            //    httpClient.Send(new HttpRequestMessage(HttpMethod.Get, "http://test.com?query=Cat_said_smth"));
            //}
        }
        public enum NoiseType
        {
            Console = 1,
            Http = 2,
            SMTP = 3
        }
    }
}
