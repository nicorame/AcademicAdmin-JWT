using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Models;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;

namespace Api_AdminAcademic.Interfaces.Service;

public interface IUsuariosService
{
    Task<ApiResponse<List<UsuarioDto>>> GetAll();
    Task<ApiResponse<UsuarioDto>> GetById(Guid id);
    Task<ApiResponse<LoginDto>> Login(string email, string password);
    Task<ApiResponse<UsuarioDto>> PostUsuario(NuevoUsuarioQuery nuevoUsuarioQuery);
    Task<ApiResponse<UsuarioDto>> DeleteUsuario(Guid id);
}