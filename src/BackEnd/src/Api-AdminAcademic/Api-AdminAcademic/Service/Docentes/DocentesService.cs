using System.Net;
using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.Docentes;

public class DocentesService : IDocentesService
{
    private readonly IDocentesRepository _docenteRepository;
    private readonly IRolesRepository _rolesRepository;
    private readonly IMapper _mapper;

    public DocentesService(IDocentesRepository docenteRepository, IRolesRepository rolesRepository,IMapper mapper)
    {
        _docenteRepository = docenteRepository;
        _rolesRepository = rolesRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<DocenteDto>>> GetAll()
    {
        var response = new ApiResponse<List<DocenteDto>>();
        var docentes = await _docenteRepository.GetAll();
        if (docentes != null && docentes.Count > 0)
        {
            response.Data = _mapper.Map<List<DocenteDto>>(docentes);
        }
        else
        {
            response.SetError("There are no docentes in the database", HttpStatusCode.Conflict);
        }

        return response;
    }

    public async Task<ApiResponse<DocenteDto>> GetById(Guid id)
    {
        var response = new ApiResponse<DocenteDto>();
        var docente = await _docenteRepository.GetById(id);
        if (docente != null)
        {
            response.Data = _mapper.Map<DocenteDto>(docente);
        }
        else
        {
            response.SetError("Unregistered Docente", HttpStatusCode.Conflict);
        }

        return response;
    }

    public async Task<ApiResponse<DocenteDto>> PostDocente(NuevoDocenteQuery nuevoDocenteQuery)
    {
        var response = new ApiResponse<DocenteDto>();
        var docenteExist = await _docenteRepository.GetById(nuevoDocenteQuery.Id);
        if (docenteExist != null)
        {
            response.SetError("The docente already exists", HttpStatusCode.Conflict);
            return response;
        }
        
        var rol = await _rolesRepository.GetById(nuevoDocenteQuery.Rol);
        if (rol == null)
        {
            response.SetError("Rol do not exist", HttpStatusCode.Conflict);
            return response;
        }

        var newDocente = new Models.Docentes
        {
            Id = nuevoDocenteQuery.Id,
            Name = nuevoDocenteQuery.Name,
            LastName = nuevoDocenteQuery.LastName,
            File = nuevoDocenteQuery.File,
            Rol = rol
        };

        newDocente = await _docenteRepository.PostAlumno(newDocente);
        response.Data = _mapper.Map<DocenteDto>(newDocente);
        return response;
    }
}