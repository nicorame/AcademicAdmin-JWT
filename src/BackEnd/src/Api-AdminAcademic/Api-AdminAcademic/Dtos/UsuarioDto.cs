namespace Api_AdminAcademic.Dtos;

public class UsuarioDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public RolesDto Rol { get; set; }
}