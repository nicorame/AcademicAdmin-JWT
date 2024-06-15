using System.ComponentModel.DataAnnotations.Schema;

namespace Api_AdminAcademic.Models;

[Table("docentes")]
public class Docentes
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string File { get; set; }
    public Guid IdRol { get; set; }

    [ForeignKey("IdRol")] public Roles Rol { get; set; }
    
    public ICollection<DocentesXCursos> DocentesXCursos { get; set; }
}