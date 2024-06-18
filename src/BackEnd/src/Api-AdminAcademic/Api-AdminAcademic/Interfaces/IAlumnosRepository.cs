using Api_AdminAcademic.Models;
using Api_AdminAcademic.Query;

namespace Api_AdminAcademic.Interfaces;

public interface IAlumnosRepository
{
    Task<List<Alumnos>> GetAll();
    Task<Alumnos> GetById(Guid id);
    Task<Alumnos> PostAlumno(Alumnos alumnos);
}