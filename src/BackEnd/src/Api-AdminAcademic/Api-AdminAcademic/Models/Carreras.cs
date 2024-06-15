using System.ComponentModel.DataAnnotations.Schema;

namespace Api_AdminAcademic.Models;

[Table("carreras")]
public class Carreras
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Cursos> Cursos { get; set; }
}