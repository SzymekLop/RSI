using Grpc.Core;

namespace GrpcServiceDistance.Services
{
    public class DistanceService : Distance.DistanceBase
    {
        private readonly ILogger<GreeterService> _logger;
        public DistanceService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<DistanceReply> CalculateDistance(TwoCityRequest request, ServerCallContext context)
        {
            return Task.FromResult(new DistanceReply
            {
               Distance  = Haversine(request.Latitude1, request.Latitude2, request.Longitude1, request.Longitude2)
            });
        }

        public override Task<DistanceReply> CalculateDistanceThrought(ThreeCityRequest request, ServerCallContext context)
        {
            return Task.FromResult(new DistanceReply
            {
                Distance = Haversine(request.Latitude1, request.Latitude2, request.Longitude1, request.Longitude2) + 
                           Haversine(request.Latitude2, request.Latitude3, request.Longitude2, request.Longitude3)
            });
        }

        private static double Haversine(double lat1, double lat2, double lon1, double lon2)
        {
            const double PIx = 3.141592653589793;
            const double RADIUS = 6378.16;

            double dlon = Radians(lon2 - lon1);
            double dlat = Radians(lat2 - lat1);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return Math.Round(angle * RADIUS, 2);

        }

        public static double Radians(double x)
        {
            return x * 3.141592653589793 / 180;
        }
    }
}
