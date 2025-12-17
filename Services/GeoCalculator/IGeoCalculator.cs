namespace EventAPI.Services
{
    public interface IGeoCalculator
    {
        double CalculateDistance(decimal lat1, decimal lon1, decimal lat2, decimal lon2);
    }
}