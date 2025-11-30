using EventAPI.Models;
using EventAPI.DTOs;

namespace EventAPI.Data.Repositories
{
    public interface IEventRepository: IRepository<Event>
    {
        Task<IEnumerable<Event>> GetNearbyEventsAsync(decimal latitude, decimal longitude, double radiusKm);        
    }
}