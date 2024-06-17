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
        var usuarios = await _usuariosRepository.GetAll();
        if (usuarios != null && usuarios.Count > 0)
        {
            response.Data = _mapper.Map<List<UsuarioDto>>(usuarios);
        }
        return response;
    }

    public async Task<ApiResponse<UsuarioDto>> GetById(Guid id)
    {
        var response = new ApiResponse<UsuarioDto>();
        var usuario = await _usuariosRepository.GetById(id);
        if (usuario != null)
        {
            response.Data = _mapper.Map<UsuarioDto>(usuario);
        }
        return response;
    }

    public async Task<ApiResponse<UsuarioDto>> PostUsuario(NuevoUsuarioQuery nuevoUsuarioQuery)
    {
        var response = new ApiResponse<UsuarioDto>();
        var usuario = await _usuariosRepository.GetById(nuevoUsuarioQuery.IdUsuario);
        if (usuario != null)
        {
            response.SetError("Usuario ya registrado", HttpStatusCode.Conflict);
            return response;
        }

        var rol = await _rolesRepository.GetById(nuevoUsuarioQuery.Rol);
        if (rol == null)
        {
            response.SetError("Rol no encontrado", HttpStatusCode.Conflict);
            return response;
        }

        var nuevoUsuario = new Models.Usuarios
        {
            Id = nuevoUsuarioQuery.IdUsuario,
            Email = nuevoUsuarioQuery.Email,
            Password = nuevoUsuarioQuery.Password,
            IdRol = nuevoUsuarioQuery.Rol
        };

        nuevoUsuario = await _usuariosRepository.PostUsuario(nuevoUsuario);
        response.Data = _mapper.Map<UsuarioDto>(nuevoUsuario);
        return response;

    }

    public async Task<ApiResponse<UsuarioDto>> DeleteUsuario(Guid id)
    {
        var response = new ApiResponse<UsuarioDto>();
        var usuario = await _usuariosRepository.GetById(id);
        if (usuario != null)
        {
            usuario = await _usuariosRepository.DeleteUsuario(id);
            response.Data = _mapper.Map<UsuarioDto>(usuario);
        }
        else
        {
            response.SetError("Usuario no registrado", HttpStatusCode.NotFound);
        }

        return response;
    }
}