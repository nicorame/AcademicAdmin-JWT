using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.Roles;

public class RolesService : IRolesService
{
    private readonly IRolesRepository _rolesRepository;
    private readonly IMapper _mapper;

    public RolesService(IRolesRepository rolesRepository, IMapper mapper)
    {
        _rolesRepository = rolesRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<RolesDto>>> GetAll()
    {
        var response = new ApiResponse<List<RolesDto>>();
        var roles = await _rolesRepository.GetAll();
        if (roles != null && roles.Count > 0)
        {
            response.Data = _mapper.Map<List<RolesDto>>(roles);
        }
        return response;
    }

    public async Task<ApiResponse<RolesDto>> GetById(Guid id)
    {
        var response = new ApiResponse<RolesDto>();
        var rol = await _rolesRepository.GetById(id);
        if (rol != null)
        {
            response.Data = _mapper.Map<RolesDto>(rol);
        }
        return response;
    }
}