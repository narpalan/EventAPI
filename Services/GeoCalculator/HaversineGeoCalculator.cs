namespace EventAPI.Services
{
    public class HaversineGeoCalculator : IGeoCalculator
    {
        private const double EarthRadiusKm = 6371.0;

        public double CalculateDistance(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
        {
            var lat1Rad = ToRadians((double)lat1);
            var lon1Rad = ToRadians((double)lon1);
            var lat2Rad = ToRadians((double)lat2);
            var lon2Rad = ToRadians((double)lon2);

            var dLat = lat2Rad - lat1Rad;
            var dLon = lon2Rad - lon1Rad;

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            
            return EarthRadiusKm * c;
        }

        private static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}