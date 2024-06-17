using Api_AdminAcademic.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api_AdminAcademic.Controllers;

public class CursosController : Controller
{
    private readonly ICursosService _cursosService;

    public CursosController(ICursosService cursosService)
    {
        _cursosService = cursosService;
    }

    [HttpGet("/cursos/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _cursosService.GetAll();
        return Ok(response);
    }

    [HttpGet("/cursos/GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _cursosService.GetById(id);
        return Ok(response);
    }
    
    
}