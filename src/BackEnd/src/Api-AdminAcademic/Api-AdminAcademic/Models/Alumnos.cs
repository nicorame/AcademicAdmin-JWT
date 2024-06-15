using System.ComponentModel.DataAnnotations.Schema;

namespace Api_AdminAcademic.Models;

[Table("alumnos")]
public class Alumnos
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string File { get; set; }
    public Guid IdRol { get; set; }
    
    [ForeignKey("IdRol")] public Roles Rol { get; set; }
    
    public ICollection<AlumnosXCursos> AlumnosXCursos { get; set; }
}