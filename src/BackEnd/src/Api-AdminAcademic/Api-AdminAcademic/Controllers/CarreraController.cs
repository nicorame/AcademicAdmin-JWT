using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Microsoft.AspNetCore.Mvc;

namespace Api_AdminAcademic.Controllers;

public class CarreraController : Controller
{
    private readonly ICarreraService _carreraService;

    public CarreraController(ICarreraService carreraService)
    {
        _carreraService = carreraService;
    }

    [HttpGet("/carreras/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _carreraService.GetAll();
        return Ok(response);
    }

    [HttpGet("/carreras/GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _carreraService.GetById(id);
        return Ok(response);
    }

    [HttpPost("/carreras/post")]
    public async Task<IActionResult> PostCarrera([FromBody] NuevaCarreraQuery query)
    {
        var response = await _carreraService.PostCarrera(query);
        return Ok(response);
    }
    
    
}