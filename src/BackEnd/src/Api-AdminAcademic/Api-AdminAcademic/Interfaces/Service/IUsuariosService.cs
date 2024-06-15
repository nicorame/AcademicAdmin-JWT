using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Models;
using Api_AdminAcademic.Response;

namespace Api_AdminAcademic.Interfaces.Service;

public interface IUsuariosService
{
    Task<ApiResponse<List<UsuarioDto>>> GetAll();
    Task<ApiResponse<UsuarioDto>> GetById(Guid id);
}