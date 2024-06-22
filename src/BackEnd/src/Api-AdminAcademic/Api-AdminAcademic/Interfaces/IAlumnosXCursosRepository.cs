using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Models;

namespace Api_AdminAcademic.Interfaces;

public interface IAlumnosXCursosRepository
{
    Task<List<AlumnosXCursos>> GetAll();
    Task<List<AlumnosXCursos>> GetByCurso(Guid id);
    Task<AlumnosXCursos> GetAlumnoByIdAndIdCurso(Guid idAlumno, Guid idCurso);
    Task<AlumnosXCursos> PostAlumnoXCurso(AlumnosXCursos alumnosXCursos);
    Task<bool> IsAlumnoInCurso(Guid idCurso, Guid idAlumno);
    Task<AlumnosXCursos> DeleteAlumno(Guid idAlumno, Guid idCurso);
}