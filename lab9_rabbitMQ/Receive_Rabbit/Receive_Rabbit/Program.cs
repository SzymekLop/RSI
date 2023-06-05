using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


MyData.MyData.info();
var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "hello-world",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);


Console.WriteLine(" [*] Waiting for messages.");

Dictionary<string, bool> senders = new Dictionary<string, bool>();

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");

    var headers = ea.BasicProperties.Headers;
    string? senderId = null;

    if (headers != null && headers.TryGetValue("SenderId", out var senderIdObj))
    {
        if (senderIdObj is byte[] senderIdBytes)
        {
            senderId = Encoding.UTF8.GetString(senderIdBytes);
            if (!senders.ContainsKey(senderId))
            {
                senders.Add(senderId, false);
            }
        }
    }

    if (message.Equals(END_MESSAGE) && senderId != null)
    {
        senders.Remove(senderId);
        senders.Add(senderId, true);
    }

};
channel.BasicConsume(queue: "hello-world",
                     autoAck: true,
                     consumer: consumer);

if()

Console.WriteLine(" Press any key to exit.");
Console.ReadLine();