using EventAPI.Models;
using EventAPI.DTOs;

namespace EventAPI.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllEventsAsync();
        Task<EventDto?> GetEventByIdAsync(int id);
        Task<EventDto> CreateEventAsync(CreateEventDto createEventDto);
        Task<EventDto?> UpdateEventAsync(int id, CreateEventDto updateEventDto);
        Task<bool> DeleteEventAsync(int id);
        Task<IEnumerable<EventDto>> GetNearbyEventsAsync(decimal latitude, decimal longitude, decimal radiusKm);
    }
}