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
        CreateMap<Cursos, CursoDtoForListDocente>();

        CreateMap<Alumnos, AlumnoDto>();
        CreateMap<Alumnos, AlumnoDtoForList>();

        CreateMap<Docentes, DocenteDto>();
        CreateMap<Docentes, DocenteDtoForList>();
        
        CreateMap<AlumnosXCursos, AlumnoXCrusoDto>();
        CreateMap<DocentesXCursos, DocenteXCursoDto>();
        
        CreateMap<Alumnos, AlumnoDtoForAlumnosXcurso>();
        CreateMap<Cursos, CursosDtoForAlumnosXcurso>();
        CreateMap<Cursos, CursosDtoForDocentesXCurso>();
        CreateMap<Docentes, DocenteDtoForDocenteXcurso>();

        CreateMap<AlumnosXCursos, AlumnoXCursoDtoForDelete>();
        CreateMap<DocentesXCursos, DocenteXCursoDtoForDelete>();
    }
}