using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Models;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;

namespace Api_AdminAcademic.Interfaces.Service;

public interface ICursosService
{
    Task<ApiResponse<List<CursosDto>>> GetAll();
    Task<ApiResponse<CursosDto>> GetById(Guid id);
    Task<ApiResponse<CursosDto>> PostCurso(NuevoCursoQuery nuevoCursoQuery);
    Task<ApiResponse<CursosDto>> UpdateCurso(UpdateCursoQuery updateCursoQuery);
    Task<ApiResponse<CursosDto>> DeleteCurso(Guid id);

}