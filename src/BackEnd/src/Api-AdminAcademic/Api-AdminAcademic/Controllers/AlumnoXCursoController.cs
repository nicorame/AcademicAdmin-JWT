using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_AdminAcademic.Controllers;

public class AlumnoXCursoController : Controller
{

    private readonly IAlumnosXCursosService _alumnosXCursosService;

    public AlumnoXCursoController(IAlumnosXCursosService alumnosXCursosService)
    {
        _alumnosXCursosService = alumnosXCursosService;
    }

    [HttpGet("alumnosXcursos/GetAll"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _alumnosXCursosService.GetAll();
        return Ok(result);
    }
    
    [HttpGet("alumnosXcursos/GetAlumnosPorCurso/{id}")]
    public async Task<IActionResult> GetByCursoDos(Guid id)
    {
        var result = await _alumnosXCursosService.GetByCurso(id);
        return Ok(result);
    }

    [HttpPost("alumnosXcursos/Post"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] NewAlumnoXCurso query)
    {
        var response = await _alumnosXCursosService.PostAlumnoXcurso(query);
        return Ok(response);
    }

    [HttpDelete("alumnosXcursos/Delete/{idAlumno}/{idCurso}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid idAlumno, Guid idCurso)
    {
        var response = await _alumnosXCursosService.DeleteAlumnoXCurso(idAlumno, idCurso);
        return Ok(response);
    }
}