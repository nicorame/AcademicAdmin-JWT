using System.Net;
using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.AlumnoXCurso;

public class AlumnosXCursosService : IAlumnosXCursosService
{
    private readonly IAlumnosXCursosRepository _alumnosXCursosRepository;
    private readonly ICursosRepository _cursosRepository;
    private readonly IMapper _mapper;

    public AlumnosXCursosService(IAlumnosXCursosRepository alumnosXCursosRepository, IMapper mapper, ICursosRepository cursosRepository)
    {
        _alumnosXCursosRepository = alumnosXCursosRepository;
        _cursosRepository = cursosRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<CursoDtoForList>>> GetAll()
    {
        var response = new ApiResponse<List<CursoDtoForList>>();

        var cursos = await _cursosRepository.GetAll();
        if (cursos == null && cursos.Count > 0)
        {
            response.SetError("No existen cursos", HttpStatusCode.NotFound);
            return response;
        }

        var alumnosXcursos = await _alumnosXCursosRepository.GetAll();
        if (alumnosXcursos == null)
        {
            response.SetError("No hay registros", HttpStatusCode.NotFound);
            return response;
        }
        
        var cursosDto = cursos.Select(curso => new CursoDtoForList
        {
            Name = curso.Name,
            Alumnos = alumnosXcursos
                .Where(ac => ac.IdCurso == curso.Id)
                .Select(ac => new AlumnoDtoForList
                {
                    Name = ac.Alumno.Name,
                    LastName = ac.Alumno.LastName
                }).ToList()
        }).ToList();

        response.Data = cursosDto;
        return response;
        
    }

    public async Task<ApiResponse<CursoDtoForList>> GetByCurso(Guid id)
    {
        var response = new ApiResponse<CursoDtoForList>();

        var curso = await _cursosRepository.GetById(id);
        if (curso == null)
        {
            response.SetError("Curso no encontrado", HttpStatusCode.NotFound);
            return response;
        }

        var alumnoXcurso = await _alumnosXCursosRepository.GetByCurso(id);
        if (alumnoXcurso == null)
        {
            response.SetError("No se encontraron alumnos para el curso", HttpStatusCode.NotFound);
            return response;
        }

        var cursoDto = new CursoDtoForList
        {
            Name = curso.Name,
            Alumnos = alumnoXcurso.Select(ac => new AlumnoDtoForList
            {
                Name = ac.Alumno.Name,
                LastName = ac.Alumno.LastName
            }).ToList()
        };

        response.Data = cursoDto;
        return response;
    }
}