namespace Api_AdminAcademic.Query;

public class NuevoUsuarioQuery
{
    public Guid IdUsuario { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid Rol { get; set; }   
}