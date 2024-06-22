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

        CreateMap<Cursos, CursosDto>();
        CreateMap<Cursos, CursoDtoForList>();

        CreateMap<Alumnos, AlumnoDto>();
        CreateMap<Alumnos, AlumnoDtoForList>();

        CreateMap<Docentes, DocenteDto>();

        CreateMap<AlumnosXCursos, AlumnoXCrusoDto>();

        CreateMap<Alumnos, AlumnoDtoForAlumnosXcurso>();
        CreateMap<Cursos, CursosDtoForAlumnosXcurso>();
    }
}