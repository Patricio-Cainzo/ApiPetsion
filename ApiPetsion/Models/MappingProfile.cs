using ApiPetsion.Models.Dto;
using AutoMapper;

namespace ApiPetsion.Models
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<UsuarioDueno,UsuarioDuenoDto>();
            CreateMap<UsuarioDuenoDto,UsuarioDueno>();
            CreateMap<Anfitrion,AnfitrionDto>();
            CreateMap<AnfitrionDto,Anfitrion>();
        }
    }
}
