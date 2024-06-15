using System.ComponentModel.DataAnnotations.Schema;

namespace Api_AdminAcademic.Models;

[Table("docentesXcursos")]
public class DocentesXCursos
{
    public Guid Id { get; set; }
    public Guid IdCurso { get; set; }
    [ForeignKey("IdCurso")] public Cursos Curso { get; set; }

    public Guid IdDocente { get; set; }
    [ForeignKey("IdDocente")] public Docentes Docente { get; set; }

    public DateTime DateAdded { get; set; }
    
}