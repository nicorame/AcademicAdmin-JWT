using System.ComponentModel.DataAnnotations.Schema;

namespace Api_AdminAcademic.Models;

[Table("cursos")]
public class Cursos
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public string Schedules { get; set; }
    public Guid IdCarrera { get; set; }
    
    [ForeignKey("IdCarrera")] public Carreras Carrera { get; set; }
    
    public ICollection<AlumnosXCursos> AlumnosXCursos { get; set; }
    public ICollection<DocentesXCursos> DocentesXCursos { get; set; }

}