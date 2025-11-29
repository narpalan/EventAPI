using AutoMapper;
using EventAPI.Models;
using EventAPI.DTOs;

namespace EventAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<CreateEventDto, Event>();
        }
    }
}