using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventAPI.Models;

namespace EventAPI.Data.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Social_Events");

            builder.HasKey(eventEntity => eventEntity.Id);

            builder.Property(eventEntity => eventEntity.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(eventEntity => eventEntity.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(eventEntity => eventEntity.Date)
                .IsRequired();

            builder.Property(eventEntity => eventEntity.Latitude)
                .IsRequired()
                .HasColumnType("decimal(9,6)");

            builder.Property(eventEntity => eventEntity.Longitude)
                .IsRequired()
                .HasColumnType("decimal(9,6)");

            builder.Property(eventEntity => eventEntity.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(eventEntity => eventEntity.CreatedAt)
                .IsRequired();
            
            //Performance indexes
            builder.HasIndex(eventEntity => eventEntity.Category); // Category filter
            builder.HasIndex(eventEntity => eventEntity.Date); // Date filter

            //Geo queries
            builder.HasIndex(eventEntity => new { eventEntity.Latitude, eventEntity.Longitude});
        } 
    }
}