using EventAPI.DTOs;

namespace EventAPI.Services
{
    public interface IEventService 
    {     
        Task<IEnumerable<EventDto>> GetAllAsync();
        Task<EventDto?> GetByIdAsync(int id);
        Task<EventDto> CreateAsync(CreateEventDto createDto);
        Task<EventDto?> UpdateAsync(int id, UpdateEventDto updateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<EventDto>> GetNearbyEventsAsync(decimal latitude, decimal longitude, decimal radiusKm);

    }
}