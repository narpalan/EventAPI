using Microsoft.EntityFrameworkCore;
using EventAPI.Models;
using EventAPI.Helpers;
using EventAPI.Services;

namespace EventAPI.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _context;
        private readonly IGeoCalculator _geoCalculator;

        public EventRepository(EventContext context, IGeoCalculator geoCalculator)
        {
            _context = context;
            _geoCalculator = geoCalculator;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<Event> AddAsync(Event eventEntity)
        {
            _context.Events.Add(eventEntity);
            await _context.SaveChangesAsync();
            return eventEntity;
        }

        public async Task<Event?> UpdateAsync(Event eventEntity)
        {
            var existingEvent = await _context.Events.FindAsync(eventEntity.Id);
            if (existingEvent == null)
            {
                return null;
            }

            _context.Entry(existingEvent).CurrentValues.SetValues(eventEntity);
            await _context.SaveChangesAsync();
            return existingEvent;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null)
            {
                return false;
            }

            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Events.AnyAsync(e => e.Id == id);
        }

         public async Task<IEnumerable<Event>> GetNearbyEventsAsync(
            decimal latitude, 
            decimal longitude, 
            double radiusKm)
        {
            var events = await _context.Events.ToListAsync();
            
            var nearbyEvents = events.Where(e => 
                _geoCalculator.CalculateDistance(
                    latitude, longitude, 
                    e.Latitude, e.Longitude) <= radiusKm
            );
            
            return nearbyEvents;
        }
    }
}