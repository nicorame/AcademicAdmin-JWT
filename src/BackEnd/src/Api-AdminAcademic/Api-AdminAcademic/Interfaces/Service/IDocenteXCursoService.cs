using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Models;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;

namespace Api_AdminAcademic.Interfaces.Service;

public interface IDocenteXCursoService
{
    Task<ApiResponse<List<CursoDtoForListDocente>>> GetAll();
    Task<ApiResponse<CursoDtoForListDocente>> GetByCurso(Guid id);
    Task<ApiResponse<DocenteXCursoDto>> PostDocenteXcurso(NewDocenteXCurso newDocenteXCurso);
    Task<ApiResponse<DocenteXCursoDto>> DeleteDocenteXcurso(Guid idCurso, Guid idDocente);
}