using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Microsoft.AspNetCore.Mvc;

namespace Api_AdminAcademic.Controllers;

public class AlumnoController : Controller
{
    private readonly IAlumnosService _alumnosService;

    public AlumnoController(IAlumnosService alumnoService)
    {
        _alumnosService = alumnoService;
    }

    [HttpGet("/alumnos/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _alumnosService.GetAll();
        return Ok(response);
    }
    
    [HttpGet("/alumnos/GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _alumnosService.GetById(id);
        return Ok(response);
    }

    [HttpPost("/alumnos/PostAlumno")]
    public async Task<IActionResult> PostAlumno([FromBody] NuevoAlumnoQuery query)
    {
        var response = await _alumnosService.PostAlumno(query);
        return Ok(response);
    }

}