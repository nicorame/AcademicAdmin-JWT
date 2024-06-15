using System.ComponentModel.DataAnnotations.Schema;

namespace Api_AdminAcademic.Models;

[Table("alumnosXcursos")]
public class AlumnosXCursos
{
    public Guid Id { get; set; }
    public Guid IdCurso { get; set; }
    [ForeignKey("IdCurso")] public Cursos Curso { get; set; }

    public Guid IdAlumno { get; set; }
    [ForeignKey("IdAlumno")] public Alumnos Alumno { get; set; }

    public DateTime DateAdded { get; set; }
}