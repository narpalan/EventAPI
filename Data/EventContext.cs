using Microsoft.EntityFrameworkCore;
using EventAPI.Models;

namespace EventAPI.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        public DbSet<Event> Events => Set<Event>();
    }
}