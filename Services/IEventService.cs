using EventAPI.DTOs;

namespace EventAPI.Services
{
    public interface IEventService : IService<EventDto, CreateEventDto, UpdateEventDto>
    {     
        Task<IEnumerable<EventDto>> GetNearbyEventsAsync(decimal latitude, decimal longitude, decimal radiusKm);
    }
}