using AutoMapper;

namespace MovieTickets.Core.Application._Shared.Mapping;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
