﻿using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_AdminAcademic.Controllers;

public class CursosController : Controller
{
    private readonly ICursosService _cursosService;

    public CursosController(ICursosService cursosService)
    {
        _cursosService = cursosService;
    }

    [HttpGet("/cursos/GetAll"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _cursosService.GetAll();
        return Ok(response);
    }

    [HttpGet("/cursos/GetById/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _cursosService.GetById(id);
        return Ok(response);
    }

    [HttpPost("/cursos/PostCursos"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> PostCursos([FromBody] NuevoCursoQuery query)
    {
        var response = await _cursosService.PostCurso(query);
        return Ok(response);
    }

    [HttpPut("/cursos/UpdateCursos"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCursos([FromBody] UpdateCursoQuery query)
    {
        var response = await _cursosService.UpdateCurso(query);
        return Ok(response);
    }

    [HttpDelete("/cursos/DeleteCursos/{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCursos(Guid id)
    {
        var response = await _cursosService.DeleteCurso(id);
        return Ok(response);
    }
}