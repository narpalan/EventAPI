using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EventAPI.Data;
using EventAPI.Models;
using EventAPI.DTOs;
using EventAPI.Helpers;

namespace EventAPI.Services
{
    public class EventService : IEventService
    {
        private readonly EventContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EventService> _logger;

        public EventService(EventContext context, IMapper mapper, ILogger<EventService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
        {
            _logger.LogInformation("Buscando todos os eventos");
            var events = await _context.Events.ToListAsync();
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<EventDto?> GetEventByIdAsync(int id)
        {
            _logger.LogInformation("Buscando evento com ID: {Id}", id);
            var eventItem = await _context.Events.FindAsync(id);
            return eventItem == null ? null : _mapper.Map<EventDto>(eventItem);
        }

        public async Task<EventDto> CreateEventAsync(CreateEventDto createEventDto)
        {
            _logger.LogInformation("Criando novo evento: {Title}", createEventDto.Title);
            
            var eventItem = _mapper.Map<Event>(createEventDto);
            _context.Events.Add(eventItem);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<EventDto>(eventItem);
        }

        public async Task<EventDto?> UpdateEventAsync(int id, CreateEventDto updateEventDto)
        {
            _logger.LogInformation("Atualizando evento com ID: {Id}", id);
            
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null) return null;

            _mapper.Map(updateEventDto, eventItem);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<EventDto>(eventItem);
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            _logger.LogInformation("Excluindo evento com ID: {Id}", id);
            
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null) return false;

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<IEnumerable<EventDto>> GetNearbyEventsAsync(decimal latitude, decimal longitude, decimal radiusKm)
        {
            _logger.LogInformation("Buscando eventos próximos a {Lat}, {Lon} com raio de {Radius}km", 
                latitude, longitude, radiusKm);

            var events = await _context.Events.ToListAsync();
            var nearbyEvents = events.Where(e => 
                GeoHelper.CalculateDistance(latitude, longitude, e.Latitude, e.Longitude) <= (double)radiusKm
            );

            return _mapper.Map<IEnumerable<EventDto>>(nearbyEvents);
        }
    }
}