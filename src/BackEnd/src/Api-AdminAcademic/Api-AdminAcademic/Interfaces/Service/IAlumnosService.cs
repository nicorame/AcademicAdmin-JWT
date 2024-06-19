using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Models;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;

namespace Api_AdminAcademic.Interfaces.Service;

public interface IAlumnosService
{
    Task<ApiResponse<List<AlumnoDto>>> GetAll();
    Task<ApiResponse<AlumnoDto>> GetById(Guid id);
    Task<ApiResponse<AlumnoDto>> PostAlumno(NuevoAlumnoQuery nuevoAlumnoQuery);
    Task<ApiResponse<AlumnoDto>> UpdateAlumno(UpdateAlumnoQuery updateAlumnoQuery);
    Task<ApiResponse<AlumnoDto>> DeleteAlumno(Guid id);
}