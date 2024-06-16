using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Models;
using AutoMapper;

namespace Api_AdminAcademic.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Roles, RolesDto>();
        CreateMap<Usuarios, UsuarioDto>();
        CreateMap<Carreras, CarrerasDto>();
    }
}