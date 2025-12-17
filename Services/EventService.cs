using AutoMapper;
using EventAPI.Data.Repositories;
using EventAPI.Models;
using EventAPI.DTOs;

namespace EventAPI.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EventService> _logger;

        public EventService(IEventRepository eventRepository, IMapper mapper, ILogger<EventService> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<EventDto>> GetAllAsync()
        {
            _logger.LogInformation("Buscando todos os eventos");
            var events = await _eventRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<EventDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Buscando evento com ID: {Id}", id);
            var eventItem = await _eventRepository.GetByIdAsync(id);
            return eventItem == null ? null : _mapper.Map<EventDto>(eventItem);
        }

        public async Task<EventDto> CreateAsync(CreateEventDto createEventDto)
        {
            _logger.LogInformation("Criando novo evento: {Title}", createEventDto.Title);
            
            var eventItem = _mapper.Map<Event>(createEventDto);
            var createdEvent = await _eventRepository.AddAsync(eventItem);
            
            return _mapper.Map<EventDto>(createdEvent);
        }

        public async Task<EventDto?> UpdateAsync(int id, UpdateEventDto updateEventDto)
        {
            _logger.LogInformation("Atualizando evento com ID: {Id}", id);
            
            var existingEvent = await _eventRepository.GetByIdAsync(id);
            if (existingEvent == null) return null;

            _mapper.Map(updateEventDto, existingEvent);
            var updatedEvent = await _eventRepository.UpdateAsync(existingEvent);
            
            return updatedEvent == null ? null : _mapper.Map<EventDto>(updatedEvent);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("Excluindo evento com ID: {Id}", id);
            return await _eventRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EventDto>> GetNearbyEventsAsync(
            decimal latitude, 
            decimal longitude, 
            decimal radiusKm)
        {
            _logger.LogInformation(
                "Buscando eventos próximos a ({Latitude}, {Longitude}) com raio de {RadiusKm}km", 
                latitude, longitude, radiusKm);

            var events = await _eventRepository.GetNearbyEventsAsync(
            latitude, longitude, (double)radiusKm);
    
            _logger.LogInformation(
                "Encontrados {EventCount} eventos no raio especificado", 
                events.Count());
    
        return _mapper.Map<IEnumerable<EventDto>>(events);
        }
    }
}