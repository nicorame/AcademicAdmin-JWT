using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace Api_AdminAcademic.Service.Usuarios;

public class UsuariosService : IUsuariosService
{
    private readonly IUsuariosRepository _usuariosRepository;
    private readonly IRolesRepository _rolesRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UsuariosService(IUsuariosRepository usuariosRepository, IMapper mapper, IRolesRepository rolesRepository, IConfiguration configuration)
    {
        _usuariosRepository = usuariosRepository;
        _rolesRepository = rolesRepository;
        _mapper = mapper;
        _configuration = configuration;
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

    public async Task<ApiResponse<LoginDto>> Login(string email, string password)
    {
        var response = new ApiResponse<LoginDto>();

        var usuario = await _usuariosRepository.GetByEmailAndPassword(email, password);
        if (usuario == null)
        {
            response.SetError("Unregistered Usuario", HttpStatusCode.NotFound);
            return response;
        }
        var token = GenerateToken(usuario);

        response.Data = new LoginDto()
        {
            Email = usuario.Email,
            Password = usuario.Password,
            Token = token
        };

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

    private string GenerateToken(Models.Usuarios usu)
    {
        var claim = new[]
        {
            new Claim(ClaimTypes.Email, usu.Email),
            new Claim("Password", usu.Password),
            new Claim(ClaimTypes.Role, usu.Rol.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken
        (
            claims: claim,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return token;
    }
    
}