using System.ComponentModel.DataAnnotations.Schema;

namespace Api_AdminAcademic.Models;

[Table("usuarios")]
public class Usuarios
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid IdRol { get; set; }
    
    [ForeignKey("IdRol")] public Roles Rol { get; set; }
}