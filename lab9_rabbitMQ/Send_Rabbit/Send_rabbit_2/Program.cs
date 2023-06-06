using Newtonsoft.Json;
using RabbitMQ.Client;
using Send_Rabbit_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Send_rabbit_2
{
    internal class Program
    {
        static void Main(string[] args)
        { 


            MyData.MyData.info();
            var factory = new ConnectionFactory { HostName = "192.168.43.40" };

            factory.Port = 5672;
            factory.UserName = "ola";
            factory.Password = "ola";
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                channel.QueueDeclare(queue: "hello-world",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                var message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);
                Console.WriteLine("You entered: " + message);

                var properties = channel.CreateBasicProperties();
                properties.Headers = new Dictionary<string, object>
                {
                    { "SenderId", "1" }
                };


                channel.BasicPublish(exchange: string.Empty,
                             routingKey: "hello",
                             basicProperties: properties,
                             body: body);
                Console.WriteLine($" [x] Sent {message}");


                //string userInput = "";
                /*    while (true)
                    {
                        Console.Write("Wprowadź wiadomość: ");
                        message = Console.ReadLine();
                        var bodyLoop = Encoding.UTF8.GetBytes(message);

                        if (message.ToLower() == "x")
                        {
                            break;
                        }

                        Console.WriteLine("Twoja wiadomość: " + message);
                        channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: bodyLoop);
                        Console.WriteLine($" [x] Wysłano {message}");
                    }*/

                for (int i = 0; i < 5; i++)
                {
                    Random rng = new Random();
                    Message myMessage = new Message(DateTime.Now, "Ola", i);
                    var json = JsonConvert.SerializeObject(myMessage);
                    var bodyLoop = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "hello-world",
                                 basicProperties: properties,
                                 body: bodyLoop);
                    Console.WriteLine($"Wysłano " + myMessage.ToString());

                    Thread.Sleep(rng.Next(2500));
                }
                var endBodyLoop = Encoding.UTF8.GetBytes("KONIEC");
                channel.BasicPublish(exchange: string.Empty,
                             routingKey: "hello-world",
                             basicProperties: properties,
                             body: endBodyLoop);
                Console.WriteLine("KONIEC");
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

        }
    }
}
