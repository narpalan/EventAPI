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

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(e => e.Date)
                .IsRequired();

            builder.Property(e => e.Latitude)
                .IsRequired()
                .HasColumnType("decimal(9,6)");

            builder.Property(e => e.Longitude)
                .IsRequired()
                .HasColumnType("decimal(9,6)");

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.CreatedAt)
                .IsRequired();
            
            //Performance indexes
            builder.HasIndex(e => e.Category); // Category filter
            builder.HasIndex(e => e.Date); // Date filter

            builder.HasIndex(e => new { e.Latitude, e.Longitude})
        } 
    }
}