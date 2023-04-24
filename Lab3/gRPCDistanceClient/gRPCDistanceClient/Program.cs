using Google.Protobuf;
using System.Threading.Tasks;
using Grpc.Net.Client;
using gRPCDistanceClient;

using var channel = GrpcChannel.ForAddress("http://192.168.43.18:2115");
var client = new Distance.DistanceClient(channel);

MyData.MyData.info();


while (true)
{

    Console.WriteLine("Nazwy miast i wartości podawaj kolejno po spacjach");
    Console.WriteLine("----------------------------------------------------------");
    Console.WriteLine("Obliczyć odległoś miedzy dwoma czy trzema miastami? (2/3)\nAby wyjść z programy wpisz 0");
    int quantity = Int32.Parse(Console.ReadLine());

    if (quantity == 0)
    {
        break;
    }

    else if (quantity == 2)
    {
        Console.WriteLine("Podaj nazwę i współrzędne pierwszego miasta");
        string? input = Console.ReadLine();
        string[] split = input.Split(" ");
        string city1 = split[0];
        double latitude1 = Double.Parse(split[1]);
        double longitude1 = Double.Parse(split[2]);

        Console.WriteLine("Podaj nazwę i współrzędne drugiego miasta");
        input = Console.ReadLine();
        split = input.Split(" ");
        string city2 = split[0];
        double latitude2 = Double.Parse(split[1]);
        double longitude2 = Double.Parse(split[2]);

        var reply = await client.CalculateDistanceAsync(
            new TwoCityRequest
            {
                Latitude1 = latitude1,
                Latitude2 = latitude2,
                Longitude1 = longitude1,
                Longitude2 = longitude2
            });

        Console.WriteLine("Odleglość pomiedzy " + city1.ToUpper() + " a " + city2.ToUpper() + " wynosi " + reply.Distance + "km");
    }
    else if (quantity == 3)
    {
        Console.WriteLine("Podaj nazwę i współrzędne pierwszego miasta");
        string? input = Console.ReadLine();
        string[] split = input.Split(" ");
        string city1 = split[0];
        double latitude1 = Double.Parse(split[1]);
        double longitude1 = Double.Parse(split[2]);

        Console.WriteLine("Podaj nazwę i współrzędne drugiego miasta");
        input = Console.ReadLine();
        split = input.Split(" ");
        string city2 = split[0];
        double latitude2 = Double.Parse(split[1]);
        double longitude2 = Double.Parse(split[2]);

        Console.WriteLine("Podaj nazwę i współrzedne trzeciego miasta");
        input = Console.ReadLine();
        split = input.Split(" ");
        string city3 = split[0];
        double latitude3 = Double.Parse(split[1]);
        double longitude3 = Double.Parse(split[2]);

        var reply = await client.CalculateDistanceThroughtAsync(
            new ThreeCityRequest
            {
                Latitude1 = latitude1,
                Latitude2 = latitude2,
                Latitude3 = latitude3,
                Longitude1 = longitude1,
                Longitude2 = longitude2,
                Longitude3 = longitude3
            });

        Console.WriteLine("Odleglość pomiedzy " + city1.ToUpper() + " a " + city3.ToUpper() + " przez " + city2.ToUpper() + " wynosi " + reply.Distance + "km");
    }
    Console.WriteLine("----------------------------------------------------------");
}