using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Response;

namespace Api_AdminAcademic.Interfaces.Service;

public interface IRolesService
{
    Task<ApiResponse<List<RolesDto>>> GetAll();
    Task<ApiResponse<RolesDto>> GetById(Guid id);
}