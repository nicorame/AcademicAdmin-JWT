using System.Net;
using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.Alumnos;

public class AlumnoService : IAlumnosService
{
    private readonly IAlumnosRepository _alumnosRepository;
    private readonly IRolesRepository _rolesRepository;
    private readonly IMapper _mapper;

    public AlumnoService(IAlumnosRepository alumnosRepository, IRolesRepository rolesRepository,IMapper mapper)
    {
        _alumnosRepository = alumnosRepository;
        _rolesRepository = rolesRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<AlumnoDto>>> GetAll()
    {
        var response = new ApiResponse<List<AlumnoDto>>();
        var alumnos = await _alumnosRepository.GetAll();
        if (alumnos != null && alumnos.Count > 0)
        {
            response.Data = _mapper.Map<List<AlumnoDto>>(alumnos);
        }
        else
        {
            response.SetError("There are no alumnos in the database", HttpStatusCode.Conflict);
        }

        return response;
    }

    public async Task<ApiResponse<AlumnoDto>> GetById(Guid id)
    {
        var response = new ApiResponse<AlumnoDto>();
        var alumno = await _alumnosRepository.GetById(id);
        if (alumno != null)
        {
            response.Data = _mapper.Map<AlumnoDto>(alumno);
        }
        else
        {
            response.SetError("Unregistered Alumno", HttpStatusCode.Conflict);
        }

        return response;
    }

    public async Task<ApiResponse<AlumnoDto>> PostAlumno(NuevoAlumnoQuery nuevoAlumnoQuery)
    {
        var response = new ApiResponse<AlumnoDto>();
        var alumnoExist = await _alumnosRepository.GetById(nuevoAlumnoQuery.Id);
        if (alumnoExist != null)
        {
            response.SetError("The alumno already exists", HttpStatusCode.Conflict);
            return response;
        }

        var rol = await _rolesRepository.GetById(nuevoAlumnoQuery.Rol);
        if (rol == null)
        {
            response.SetError("Rol do not exist", HttpStatusCode.Conflict);
            return response;
        }

        var newAlumno = new Models.Alumnos
        {
            Id = nuevoAlumnoQuery.Id,
            Name = nuevoAlumnoQuery.Name,
            LastName = nuevoAlumnoQuery.LastName,
            File = nuevoAlumnoQuery.File,
            Rol = rol
        };

        newAlumno = await _alumnosRepository.PostAlumno(newAlumno);
        response.Data = _mapper.Map<AlumnoDto>(newAlumno);

        return response;

    }
}