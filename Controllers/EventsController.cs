using Microsoft.AspNetCore.Mvc;
using EventAPI.Services;
using EventAPI.DTOs;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ILogger<EventsController> _logger;

        public EventsController(IEventService eventService, ILogger<EventsController> logger)
        {
            _eventService = eventService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var eventItem = await _eventService.GetByIdAsync(id);
            if (eventItem == null) return NotFound();
            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(CreateEventDto createEventDto)
        {
            var eventItem = await _eventService.CreateAsync(createEventDto);
            return CreatedAtAction(nameof(GetEvent), new { id = eventItem.Id }, eventItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EventDto>> UpdateEvent(int id, UpdateEventDto updateEventDto)
        {
            var eventItem = await _eventService.UpdateAsync(id, updateEventDto);
            if (eventItem == null) return NotFound();
            return Ok(eventItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var result = await _eventService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet("nearby")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetNearbyEvents(
            [FromQuery] decimal latitude, 
            [FromQuery] decimal longitude, 
            [FromQuery] decimal radius = 10)
        {
            var events = await _eventService.GetNearbyEventsAsync(latitude, longitude, radius);
            return Ok(events);
        }

        [HttpGet("debug")]
        public ActionResult<string> Debug()
        {
            return Ok($"API funcionando! Ambiente: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")} - {DateTime.Now}");
        }
    }
}