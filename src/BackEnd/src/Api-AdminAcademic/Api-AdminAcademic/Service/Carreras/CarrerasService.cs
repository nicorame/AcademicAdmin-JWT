using System.Net;
using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;
using AutoMapper;

namespace Api_AdminAcademic.Service.Carreras;

public class CarrerasService : ICarreraService
{
    private readonly ICarrerasRepository _carrerasRepository;
    private readonly IMapper _mapper;

    public CarrerasService(ICarrerasRepository carrerasRepository, IMapper mapper)
    {
        _carrerasRepository = carrerasRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<CarrerasDto>>> GetAll()
    {
        var response = new ApiResponse<List<CarrerasDto>>();
        var carreras = await _carrerasRepository.GetAll();
        if (carreras != null && carreras.Count > 0)
        {
            response.Data = _mapper.Map<List<CarrerasDto>>(carreras);
        }
        return response;
    }

    public async Task<ApiResponse<CarrerasDto>> GetById(Guid id)
    {
        var response = new ApiResponse<CarrerasDto>();
        var carrera = await _carrerasRepository.GetById(id);
        if (carrera != null)
        {
            response.Data = _mapper.Map<CarrerasDto>(carrera);
        }
        return response;
    }

    public async Task<ApiResponse<CarrerasDto>> PostCarrera(NuevaCarreraQuery nuevaCarreraQuery)
    {
        var response = new ApiResponse<CarrerasDto>();
        var existe = await _carrerasRepository.GetById(nuevaCarreraQuery.Id);
        if (existe != null) 
        {
            response.SetError("Carrera ya registrado", HttpStatusCode.Conflict);
            return response;
        }

        var nuevaCarrera = new Models.Carreras
        {
            Id = nuevaCarreraQuery.Id,
            Name = nuevaCarreraQuery.Name
        };

        nuevaCarrera = await _carrerasRepository.PostCarreras(nuevaCarrera);
        response.Data = _mapper.Map<CarrerasDto>(nuevaCarrera);
        return response;
    }
}