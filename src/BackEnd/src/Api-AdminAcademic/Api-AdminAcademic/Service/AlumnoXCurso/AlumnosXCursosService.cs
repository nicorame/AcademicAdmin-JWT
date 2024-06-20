using System.Net;
using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.AlumnoXCurso;

public class AlumnosXCursosService : IAlumnosXCursosService
{
    private readonly IAlumnosXCursosRepository _alumnosXCursosRepository;
    private readonly IMapper _mapper;

    public AlumnosXCursosService(IAlumnosXCursosRepository alumnosXCursosRepository, IMapper mapper)
    {
        _alumnosXCursosRepository = alumnosXCursosRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<AlumnoXCrusoDto>>> GetByCurso(Guid id)
    {
        var response = new ApiResponse<List<AlumnoXCrusoDto>>();
        var alumnoXcurso = await _alumnosXCursosRepository.GetByCurso(id);
        if (alumnoXcurso != null)
        {
            response.Data = _mapper.Map<List<AlumnoXCrusoDto>>(alumnoXcurso);
        }
        return response;
    }
}