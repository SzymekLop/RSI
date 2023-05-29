using System.Text;
using System.Text.RegularExpressions;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "192.168.0.103" };

factory.Port = 5672;
factory.UserName = "szymek";
factory.Password = "szymek";
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
    channel.BasicPublish(exchange: string.Empty,
                 routingKey: "hello",
                 basicProperties: null,
                 body: body);
    Console.WriteLine($" [x] Sent {message}");


    //string userInput = "";
    while (true)
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
    }




}
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();