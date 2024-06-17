using Api_AdminAcademic.Interfaces.Service;
using Api_AdminAcademic.Query;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api_AdminAcademic.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuariosService _usuariosService;

    public UsuarioController(IUsuariosService usuariosService)
    {
        _usuariosService = usuariosService;
    }

    [HttpGet("/usuarios/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _usuariosService.GetAll();
        return Ok(response);
    }

    [HttpGet("/usuarios/GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _usuariosService.GetById(id);
        return Ok(response);
    }

    [HttpPost("/usuarios/post")]
    public async Task<IActionResult> PostUsuario([FromBody] NuevoUsuarioQuery query)
    {
        var response = await _usuariosService.PostUsuario(query);
        return Ok(response);
    }

    [HttpDelete("usuarios/delete/{id}")]
    public async Task<IActionResult> DeleteUsuario(Guid id)
    {
        var response = await _usuariosService.DeleteUsuario(id);
        return Ok(response);
    }

}