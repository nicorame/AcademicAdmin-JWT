using Api_AdminAcademic.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api_AdminAcademic.Controllers;

public class AlumnoXCursoController : Controller
{

    private readonly IAlumnosXCursosService _alumnosXCursosService;

    public AlumnoXCursoController(IAlumnosXCursosService alumnosXCursosService)
    {
        _alumnosXCursosService = alumnosXCursosService;
    }

    [HttpGet("alumnosXcursos/GetAll")]
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
}