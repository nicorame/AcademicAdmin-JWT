using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Models;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;

namespace Api_AdminAcademic.Interfaces.Service;

public interface IAlumnosXCursosService
{
    Task<ApiResponse<List<CursoDtoForList>>> GetAll();
    Task<ApiResponse<CursoDtoForList>> GetByCurso(Guid id);
    Task<ApiResponse<AlumnoXCrusoDto>> PostAlumnoXcurso(NewAlumnoXCurso newAlumnoXCurso);
}