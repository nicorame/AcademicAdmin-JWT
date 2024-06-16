using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;

namespace Api_AdminAcademic.Interfaces.Service;

public interface ICarreraService
{
    Task<ApiResponse<List<CarrerasDto>>> GetAll();
    Task<ApiResponse<CarrerasDto>> GetById(Guid id);
    Task<ApiResponse<CarrerasDto>> PostCarrera(NuevaCarreraQuery nuevaCarreraQuery);
}