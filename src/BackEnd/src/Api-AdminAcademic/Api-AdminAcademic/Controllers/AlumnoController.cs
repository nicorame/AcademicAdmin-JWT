using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("/alumnos/PostAlumno"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> PostAlumno([FromBody] NuevoAlumnoQuery query)
    {
        var response = await _alumnosService.PostAlumno(query);
        return Ok(response);
    }

    [HttpPut("/alumnos/updateAlumno"), Authorize(Roles = "Alumno")]
    public async Task<IActionResult> UpdateAlumno([FromBody] UpdateAlumnoQuery query)
    {
        var response = await _alumnosService.UpdateAlumno(query);
        return Ok(response);
    }

    [HttpDelete("/alumnos/deleteAlumno/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAlumno(Guid id)
    {
        var response = await _alumnosService.DeleteAlumno(id);
        return Ok(response);
    }


}