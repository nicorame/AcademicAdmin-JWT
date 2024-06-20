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

    [HttpGet("/alumnosXCurso/GetByCurso/{id}")]
    public async Task<IActionResult> GetByCurso(Guid id)
    {
        var response = await _alumnosXCursosService.GetByCurso(id);
        return Ok(response);
    }
}