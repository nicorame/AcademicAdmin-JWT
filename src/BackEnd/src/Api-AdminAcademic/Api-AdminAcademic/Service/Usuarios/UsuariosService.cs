using System.Net;
using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.Usuarios;

public class UsuariosService : IUsuariosService
{
    private readonly IUsuariosRepository _usuariosRepository;
    private readonly IRolesRepository _rolesRepository;
    private readonly IMapper _mapper;

    public UsuariosService(IUsuariosRepository usuariosRepository, IMapper mapper, IRolesRepository rolesRepository)
    {
        _usuariosRepository = usuariosRepository;
        _rolesRepository = rolesRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<UsuarioDto>>> GetAll()
    {
        var response = new ApiResponse<List<UsuarioDto>>();
        var user = await _usuariosRepository.GetAll();
        if (user != null && user.Count > 0)
        {
            response.Data = _mapper.Map<List<UsuarioDto>>(user);
        }
        return response;
    }

    public async Task<ApiResponse<UsuarioDto>> GetById(Guid id)
    {
        var response = new ApiResponse<UsuarioDto>();
        var user = await _usuariosRepository.GetById(id);
        if (user != null)
        {
            response.Data = _mapper.Map<UsuarioDto>(user);
        }
        return response;
    }

    public async Task<ApiResponse<UsuarioDto>> PostUsuario(NuevoUsuarioQuery nuevoUsuarioQuery)
    {
        var response = new ApiResponse<UsuarioDto>();
        var user = await _usuariosRepository.GetById(nuevoUsuarioQuery.IdUsuario);
        if (user != null)
        {
            response.SetError("Already registered usuario", HttpStatusCode.Conflict);
            return response;
        }

        var rol = await _rolesRepository.GetById(nuevoUsuarioQuery.Rol);
        if (rol == null)
        {
            response.SetError("Rol not found", HttpStatusCode.NotFound);
            return response;
        }

        var newUsuario = new Models.Usuarios
        {
            Id = nuevoUsuarioQuery.IdUsuario,
            Email = nuevoUsuarioQuery.Email,
            Password = nuevoUsuarioQuery.Password,
            IdRol = nuevoUsuarioQuery.Rol
        };

        newUsuario = await _usuariosRepository.PostUsuario(newUsuario);
        response.Data = _mapper.Map<UsuarioDto>(newUsuario);
        return response;

    }

    public async Task<ApiResponse<UsuarioDto>> DeleteUsuario(Guid id)
    {
        var response = new ApiResponse<UsuarioDto>();
        var user = await _usuariosRepository.GetById(id);
        if (user != null)
        {
            user = await _usuariosRepository.DeleteUsuario(id);
            response.Data = _mapper.Map<UsuarioDto>(user);
        }
        else
        {
            response.SetError("Unregistered Usuario", HttpStatusCode.NotFound);
        }

        return response;
    }
}