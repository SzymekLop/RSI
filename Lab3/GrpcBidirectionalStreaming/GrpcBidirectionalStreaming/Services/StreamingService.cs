using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcBidirectionalStreaming;

namespace GrpcBidirectionalStreaming.Services
{
    public class StramingService : Streaming.StreamingBase
    {

        private readonly ILogger<GreeterService> _logger;
        public StramingService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override async Task StreamingPhoto(PhotoRequest request, IServerStreamWriter<PhotoResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine("toDzaiala");
            string path = String.Format(@"Streaming\{0}.jpg", request.Name);

            if(!File.Exists(path))
            {
                path = @"Streaming\default.jpg";
            }
            using (var fileStream = File.OpenRead(path))
            {
                byte[] buffer = new byte[2048]; // 4KB buffer size

                int bytesRead = 0;
                int package = 0;
                while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    var photoData = new PhotoResponse { Data = ByteString.CopyFrom(buffer, 0, bytesRead) };
                    await responseStream.WriteAsync(photoData);
                    Console.WriteLine("Wysłano pakiet " + package++);
                }
            }
        }

        public override async Task<PhotoUploadResponse> StreamingPhotoUpload(IAsyncStreamReader<PhotoUploadRequest> requestStream, ServerCallContext context)
        {
            // Create a file stream to write the received data
            Console.WriteLine("dzaiala");
            await requestStream.MoveNext();
            using (var fileStream = File.Create(String.Format(@"Streaming\{0}.jpg", requestStream.Current.Name)))
            {
                int package = 0;
                do
                {
                    PhotoUploadRequest photoData = requestStream.Current;
                    await fileStream.WriteAsync(photoData.Data.ToByteArray());
                    Console.WriteLine("Przesłano pakit "+package++);
                }
                while (await requestStream.MoveNext());
            }

            return new PhotoUploadResponse
            {
                Info = "Zakończono przesyłanie"
            };
        }
    }
}
