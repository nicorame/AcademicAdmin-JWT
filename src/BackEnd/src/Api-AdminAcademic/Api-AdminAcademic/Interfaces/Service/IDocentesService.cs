using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;

namespace Api_AdminAcademic.Interfaces.Service;

public interface IDocentesService
{
    Task<ApiResponse<List<DocenteDto>>> GetAll();
    Task<ApiResponse<DocenteDto>> GetById(Guid id);
    Task<ApiResponse<DocenteDto>> PostDocente(NuevoDocenteQuery nuevoDocenteQuery);
    Task<ApiResponse<DocenteDto>> UpdateDocente(UpdateDocenteQuery updateDocenteQuery);
    Task<ApiResponse<DocenteDto>> DeleteDocente(Guid id);
}