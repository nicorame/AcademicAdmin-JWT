using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.Usuarios;

public class UsuariosService : IUsuariosService
{
    private readonly IUsuariosRepository _usuariosRepository;
    private readonly IMapper _mapper;

    public UsuariosService(IUsuariosRepository usuariosRepository, IMapper mapper)
    {
        _usuariosRepository = usuariosRepository;
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
}