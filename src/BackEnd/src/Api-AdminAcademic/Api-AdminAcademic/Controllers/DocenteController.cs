using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Microsoft.AspNetCore.Mvc;

namespace Api_AdminAcademic.Controllers;

public class DocenteController : Controller
{
    private readonly IDocentesService _docentesService;

    public DocenteController(IDocentesService docentesService)
    {
        _docentesService = docentesService;
    }

    [HttpGet("/docentes/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _docentesService.GetAll();
        return Ok(response);
    }
    
    [HttpGet("/docentes/GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _docentesService.GetById(id);
        return Ok(response);
    }

    [HttpPost("/docentes/PostAlumno")]
    public async Task<IActionResult> PostAlumno([FromBody] NuevoDocenteQuery query)
    {
        var response = await _docentesService.PostDocente(query);
        return Ok(response);
    }

}