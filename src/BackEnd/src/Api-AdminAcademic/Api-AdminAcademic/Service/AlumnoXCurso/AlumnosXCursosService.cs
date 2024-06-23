using System.Net;
using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Models;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.AlumnoXCurso;

public class AlumnosXCursosService : IAlumnosXCursosService
{
    private readonly IAlumnosXCursosRepository _alumnosXCursosRepository;
    private readonly ICursosRepository _cursosRepository;
    private readonly IAlumnosRepository _alumnosRepository;
    private readonly IMapper _mapper;

    public AlumnosXCursosService(IAlumnosXCursosRepository alumnosXCursosRepository, IMapper mapper, ICursosRepository cursosRepository, IAlumnosRepository alumnosRepository)
    {
        _alumnosXCursosRepository = alumnosXCursosRepository;
        _cursosRepository = cursosRepository;
        _alumnosRepository = alumnosRepository;
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
            Id = curso.Id,
            Name = curso.Name,
            Alumnos = alumnosXcursos
                .Where(ac => ac.IdCurso == curso.Id)
                .Select(ac => new AlumnoDtoForList
                {
                    Name = ac.Alumno.Name,
                    LastName = ac.Alumno.LastName,
                    File = ac.Alumno.File
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
            Id = curso.Id,
            Name = curso.Name,
            Alumnos = alumnoXcurso.Select(ac => new AlumnoDtoForList
            {
                Id = ac.Alumno.Id,
                Name = ac.Alumno.Name,
                LastName = ac.Alumno.LastName,
                File = ac.Alumno.File
            }).ToList()
        };

        response.Data = cursoDto;
        return response;
    }

    public async Task<ApiResponse<AlumnoXCrusoDto>> PostAlumnoXcurso(NewAlumnoXCurso newAlumnoXCurso)
    {
        var response = new ApiResponse<AlumnoXCrusoDto>();
        var curso = await _cursosRepository.GetById(newAlumnoXCurso.Curso);
        if (curso == null)
        {
            response.SetError("Curso no encontrado", HttpStatusCode.NotFound);
            return response;
        }

        var alumno = await _alumnosRepository.GetById(newAlumnoXCurso.Alumno);
        if (curso == null)
        {
            response.SetError("Alumno no encontrado", HttpStatusCode.NotFound);
            return response;
        }
        
        var exists = await _alumnosXCursosRepository.IsAlumnoInCurso(newAlumnoXCurso.Curso, newAlumnoXCurso.Alumno);
        if (exists)
        {
            response.SetError("El alumno ya está inscrito en el curso", HttpStatusCode.BadRequest);
            return response;
        }

        var alumnoXcurso = new AlumnosXCursos()
        {
            Id = Guid.NewGuid(),
            Curso = curso,
            Alumno = alumno,
            DateAdded = DateTime.Today
        };

        alumnoXcurso = await _alumnosXCursosRepository.PostAlumnoXCurso(alumnoXcurso);
        response.Data = _mapper.Map<AlumnoXCrusoDto>(alumnoXcurso);
        return response;
    }

    public async Task<ApiResponse<AlumnoXCrusoDto>> DeleteAlumnoXCurso(Guid idAlumno, Guid idCurso)
    {
        var response = new ApiResponse<AlumnoXCrusoDto>();
        var alumnoXcurso =  await _alumnosXCursosRepository.GetAlumnoByIdAndIdCurso(idAlumno, idCurso);
        if (alumnoXcurso == null)
        {
            response.SetError("Alumno no esta registrado en este curso", HttpStatusCode.Conflict);
            return response;
        }
        alumnoXcurso = await _alumnosXCursosRepository.DeleteAlumno(idAlumno, idCurso);
        response.Data = _mapper.Map<AlumnoXCrusoDto>(alumnoXcurso);
        return response;
    }
}