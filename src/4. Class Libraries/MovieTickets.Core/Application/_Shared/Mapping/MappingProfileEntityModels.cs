using AutoMapper;
using MovieTickets.Core.Application._Shared.Models.EntityModels;
using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Core.Application._Shared.Mapping;

public class MappingProfileEntityModels : Profile
{
    public MappingProfileEntityModels()
    {
        CreateMap<Movie, MovieModel>().ReverseMap();
        CreateMap<Gender, GenderModel>().ReverseMap();
        CreateMap<MovieDirector, MovieDirectorModel>().ReverseMap();
        CreateMap<MovieActor, MovieActorModel>().ReverseMap();
        CreateMap<MovieGender, MovieGenderModel>().ReverseMap();
        CreateMap<Person, PersonModel>().ReverseMap();
    }
}
