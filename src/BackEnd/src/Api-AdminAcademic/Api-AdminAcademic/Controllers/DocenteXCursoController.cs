using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Microsoft.AspNetCore.Mvc;

namespace Api_AdminAcademic.Controllers;

public class DocenteXCursoController : Controller
{
    private readonly IDocenteXCursoService _docenteXCursoService;

    public DocenteXCursoController(IDocenteXCursoService docenteXCursoService)
    {
        _docenteXCursoService = docenteXCursoService;
    }
    
    [HttpGet("docenteXcurso/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _docenteXCursoService.GetAll();
        return Ok(result);
    }
    
    [HttpGet("docenteXcurso/GetByCurso/{id}")]
    public async Task<IActionResult> GetByCurso(Guid id)
    {
        var result = await _docenteXCursoService.GetByCurso(id);
        return Ok(result);
    }

    [HttpPost("docenteXcurso/Post")]
    public async Task<IActionResult> Post([FromBody] NewDocenteXCurso query)
    {
        var response = await _docenteXCursoService.PostDocenteXcurso(query);
        return Ok(response);
    }
    [HttpDelete("docenteXcurso/Delete/{idCurso}/{idDocente}")]
    public async Task<IActionResult> Delete(Guid idCurso, Guid idDocente)
    {
        var response = await _docenteXCursoService.DeleteDocenteXcurso(idCurso, idDocente);
        return Ok(response);
    }
}