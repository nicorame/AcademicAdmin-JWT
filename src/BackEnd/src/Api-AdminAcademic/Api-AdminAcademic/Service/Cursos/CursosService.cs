using System.Net;
using Api_AdminAcademic.Data;
using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.Cursos;

public class CursosService : ICursosService
{
    private readonly ICursosRepository _cursosRepository;
    private readonly ICarrerasRepository _carrerasRepository;
    private readonly IMapper _mapper;

    public CursosService(ICursosRepository cursosRepository, ICarrerasRepository carrerasRepository, IMapper mapper)
    {
        _cursosRepository = cursosRepository;
        _carrerasRepository = carrerasRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<CursosDto>>> GetAll()
    {
        var response = new ApiResponse<List<CursosDto>>();
        var cursos = await _cursosRepository.GetAll();
        if (cursos != null && cursos.Count > 0)
        {
            response.Data = _mapper.Map<List<CursosDto>>(cursos);
        }
        else
        {
            response.SetError("There are no cursos", HttpStatusCode.Conflict);
        }
        return response;
    }

    public async Task<ApiResponse<CursosDto>> GetById(Guid id)
    {
        var response = new ApiResponse<CursosDto>();
        var curso = await _cursosRepository.GetById(id);
        if (curso != null)
        {
            response.Data = _mapper.Map<CursosDto>(curso);
        }
        else
        {
            response.SetError("Curso not found", HttpStatusCode.NotFound);
        }
        return response;
    }

    public async Task<ApiResponse<CursosDto>> PostCurso(NuevoCursoQuery nuevoCursoQuery)
    {
        var response = new ApiResponse<CursosDto>();
        var existCurso = await _cursosRepository.GetById(nuevoCursoQuery.Id);
        if (existCurso != null)
        {
            response.SetError("Cursos already registered", HttpStatusCode.Conflict);
            return response;
        }

        var carrera = await _carrerasRepository.GetById(nuevoCursoQuery.Carrera);
        if (carrera == null)
        {
            response.SetError("Carrera does not exist", HttpStatusCode.Conflict);
            return response;
        }

        var newCurso = new Models.Cursos
        {
            Id = nuevoCursoQuery.Id,
            Name = nuevoCursoQuery.Name,
            CreationDate = DateTime.Now,
            Schedules = nuevoCursoQuery.Schedules,
            Carrera = carrera
        };

        newCurso = await _cursosRepository.PostCursos(newCurso);
        response.Data = _mapper.Map<CursosDto>(newCurso);

        return response;
    }

    public async Task<ApiResponse<CursosDto>> UpdateCurso(UpdateCursoQuery updateCursoQuery)
    {
        var response = new ApiResponse<CursosDto>();
        var existCurso = await _cursosRepository.GetById(updateCursoQuery.Id);
        if (existCurso == null)
        {
            response.SetError("Cursos do not exist", HttpStatusCode.Conflict);
            return response;
        }

        var carrera = await _carrerasRepository.GetById(updateCursoQuery.Carrera);
        if (carrera == null)
        {
            response.SetError("Carrera do not exist", HttpStatusCode.Conflict);
            return response;
        }

        var updateCurso = new Models.Cursos
        {
            Id = updateCursoQuery.Id,
            Name = updateCursoQuery.Name,
            CreationDate = DateTime.Now,
            Schedules = updateCursoQuery.Schedules,
            Carrera = carrera
        };

        updateCurso = await _cursosRepository.UpdateCursos(updateCurso);
        response.Data = _mapper.Map<CursosDto>(updateCurso);
        return response;
    }

    public async Task<ApiResponse<CursosDto>> DeleteCurso(Guid id)
    {
        var response = new ApiResponse<CursosDto>();
        var curso = await _cursosRepository.GetById(id);
        if (curso == null)
        {
            response.SetError("Cursos do not exist", HttpStatusCode.Conflict);
            return response;
        }

        curso = await _cursosRepository.DeleteCursos(id);
        response.Data = _mapper.Map<CursosDto>(curso);
        return response;
    }
}