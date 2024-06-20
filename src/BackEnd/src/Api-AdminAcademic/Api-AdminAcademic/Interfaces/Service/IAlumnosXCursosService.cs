using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Response;

namespace Api_AdminAcademic.Interfaces.Service;

public interface IAlumnosXCursosService
{
    Task<ApiResponse<List<AlumnoXCrusoDto>>> GetByCurso(Guid id);
}