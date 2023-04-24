using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

using var channel = GrpcChannel.ForAddress("http://192.168.43.18:7288");
var client = new Greeter.GreeterClient(channel);
MyData.MyData.info();
Console.Write("Podaj swoje imię: ");
String? name = Console.ReadLine();
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = name });
Console.WriteLine("Powitanie od serwera: " + reply.Message);
Console.WriteLine("Naciśnij dowolny przycisk, aby wyjść");
Console.ReadKey();