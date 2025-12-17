using Microsoft.EntityFrameworkCore;
using EventAPI.Data;
using EventAPI.Services;
using EventAPI.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

//Set up connection string

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                    ?? builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EventContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(11, 4, 0))
    )
);

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateEventValidator>();

// Services
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IGeoCalculator, HaversineGeoCalculator>();

// Logging
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Create database and tables
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EventContext>();
    db.Database.Migrate();
}

app.Run();
