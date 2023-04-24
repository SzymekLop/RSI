using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;
using MyData;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7288");
var client = new Greeter.GreeterClient(channel);
MyData.MyData.info();
Console.WriteLine();
foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
{
    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
    {
        if (ni.Name == "Wi-Fi")
        {
            foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
            {
                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip.Address.ToString());
                }
            }
        }
    }
}
Console.Write("Tell me your name: ");
String name = Console.ReadLine();
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = name });
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();