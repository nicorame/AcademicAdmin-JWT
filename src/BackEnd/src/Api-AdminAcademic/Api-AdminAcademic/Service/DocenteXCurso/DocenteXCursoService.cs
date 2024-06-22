using System.Net;
using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Models;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.DocenteXCurso;

public class DocenteXCursoService : IDocenteXCursoService
{
    private readonly IDocenteXCursoRepository _docenteXCursoRepository;
    private readonly ICursosRepository _cursosRepository;
    private readonly IDocentesRepository _docentesRepository;
    private readonly IMapper _mapper;

    public DocenteXCursoService(IDocenteXCursoRepository docenteXCursoRepository, ICursosRepository cursosRepository,
        IDocentesRepository docentesRepository, IMapper mapper)
    {
        _docenteXCursoRepository = docenteXCursoRepository;
        _cursosRepository = cursosRepository;
        _docentesRepository = docentesRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<CursoDtoForListDocente>>> GetAll()
    {
        var response = new ApiResponse<List<CursoDtoForListDocente>>();
        
        var cursos = await _cursosRepository.GetAll();
        if (cursos == null && cursos.Count > 0)
        {
            response.SetError("No existen cursos", HttpStatusCode.NotFound);
            return response;
        }

        var docenteXcurso = await _docenteXCursoRepository.GetAl();
        if (docenteXcurso == null)
        {
            response.SetError("No hay registros", HttpStatusCode.NotFound);
            return response;
        }
        
        var cursosDto = cursos.Select(curso => new CursoDtoForListDocente
        {
            Name = curso.Name,
            Docentes = docenteXcurso
                .Where(ac => ac.IdCurso == curso.Id)
                .Select(ac => new DocenteDtoForList
                {
                    Name = ac.Docente.Name,
                    LastName = ac.Docente.LastName
                }).ToList()
        }).ToList();

        response.Data = cursosDto;
        return response;
    }

    public async Task<ApiResponse<CursoDtoForListDocente>> GetByCurso(Guid id)
    {
        var response = new ApiResponse<CursoDtoForListDocente>();
        
        var curso = await _cursosRepository.GetById(id);
        if (curso == null)
        {
            response.SetError("No existen cursos", HttpStatusCode.NotFound);
            return response;
        }

        var docenteXcurso = await _docenteXCursoRepository.GetById(id);
        if (docenteXcurso == null)
        {
            response.SetError("No hay registros", HttpStatusCode.NotFound);
            return response;
        }
        
        var cursoDto = new CursoDtoForListDocente()
        {
            Name = curso.Name,
            Docentes = docenteXcurso.Select(dc => new DocenteDtoForList()
            {
                Name = dc.Docente.Name,
                LastName = dc.Docente.LastName
            }).ToList()
        };
        response.Data = cursoDto;
        return response;
    }

    public async Task<ApiResponse<DocenteXCursoDto>> PostDocenteXcurso(NewDocenteXCurso newDocenteXCurso)
    {
        var response = new ApiResponse<DocenteXCursoDto>();
        var curso = await _cursosRepository.GetById(newDocenteXCurso.Curso);
        if (curso == null)
        {
            response.SetError("Curso no encontrado", HttpStatusCode.NotFound);
            return response;
        }

        var docente = await _docentesRepository.GetById(newDocenteXCurso.Docente);
        if (docente == null)
        {
            response.SetError("Docente no encontrado", HttpStatusCode.NotFound);
            return response;
        }
        
        var exists = await _docenteXCursoRepository.GetByIdCursoAndIdDocente(newDocenteXCurso.Curso, newDocenteXCurso.Docente);
        if (exists != null)
        {
            response.SetError("El docente ya está inscrito en el curso", HttpStatusCode.BadRequest);
            return response;
        }

        var docenteXcurso = new DocentesXCursos()
        {
            Id = Guid.NewGuid(),
            Curso = curso,
            Docente = docente,
            DateAdded = DateTime.Today
        };

        docenteXcurso = await _docenteXCursoRepository.PostDocenteXCurso(docenteXcurso);
        response.Data = _mapper.Map<DocenteXCursoDto>(docenteXcurso);
        return response;
    }

    public async Task<ApiResponse<DocenteXCursoDto>> DeleteDocenteXcurso(Guid idCurso, Guid idDocente)
    {
        var response = new ApiResponse<DocenteXCursoDto>();
        var docenteXcurso = await _docenteXCursoRepository.GetByIdCursoAndIdDocente(idCurso, idDocente);
        if (docenteXcurso == null)
        {
            response.SetError("El docente no esta registrado en el curos", HttpStatusCode.Conflict);
            return response;
        }

        docenteXcurso = await _docenteXCursoRepository.DeleteDocenteXCurso(idCurso, idDocente);
        response.Data = _mapper.Map<DocenteXCursoDto>(docenteXcurso);
        return response;
    }
}