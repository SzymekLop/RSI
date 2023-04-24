using System.Threading.Tasks;
using System.Xml.Linq;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcStreamingClient;


// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://192.168.43.18:2115");
var client = new Streaming.StreamingClient(channel);


while (true)
{
    Console.WriteLine("1 - Wysyłanie pliku");
    Console.WriteLine("2 - Pobieranie pliku");
    Console.WriteLine("0 - Wyjście");
    string? choice = Console.ReadLine();

    if (choice == "0")
    {
        break;
    }
    else
    {
        Console.Write("Podaj nazwę pliku: ");
        string? name = Console.ReadLine();

        string path = String.Format(@"Streaming\{0}", name);

        if (choice == "1")
        {
            try
            {
                using (var fileStream = File.OpenRead(path))
                {
                    // Create a stream of ImageData objects
                    using (var call = client.StreamingPhotoUpload())
                    {
                        // Stream the file data to the server
                        byte[] buffer = new byte[2048];
                        int bytesRead;
                        int packages = 0;
                        while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await call.RequestStream.WriteAsync(new PhotoUploadRequest { Name = name, Data = Google.Protobuf.ByteString.CopyFrom(buffer, 0, bytesRead) });
                            Console.WriteLine("Numer paczki " + packages++);
                        }
                        await call.RequestStream.CompleteAsync();

                        var replay = await call.ResponseAsync;

                        Console.WriteLine(replay.Info);
                    }

                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Błędna nazwa pliku!");
            }
        }
        if (choice == "2")
        {
            using (var call = client.StreamingPhoto(new PhotoRequest { Name = name }))
            {
                using (var fileStream = File.Create(path))
                {

                    // Read data from the server stream and write it to the file stream
                    int packagesCount = 0;

                    while (await call.ResponseStream.MoveNext())
                    {
                        PhotoResponse imageData = call.ResponseStream.Current;
                        await fileStream.WriteAsync(imageData.Data.ToByteArray());
                        Console.WriteLine("Numer pakietu: " + packagesCount++);
                    }

                    Console.WriteLine("Download ended");
                }
            }
        }
    }
}
await channel.ShutdownAsync();