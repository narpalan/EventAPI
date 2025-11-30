using EventAPI.Models;
using EventAPI.DTOs;

namespace EventAPI.Data.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(int id);
        Task<Event> AddAsync(Event eventEntity);
        Task<Event?> UpdateAsync(Event eventEntity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Event>> GetNearbyEventsAsync(decimal latitude, decimal longitude, double radiusKm);
        Task<bool> ExistsAsync(int id);
    }
}