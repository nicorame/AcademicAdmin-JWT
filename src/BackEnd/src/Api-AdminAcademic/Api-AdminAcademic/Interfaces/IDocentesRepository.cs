using Api_AdminAcademic.Models;

namespace Api_AdminAcademic.Interfaces;

public interface IDocentesRepository
{
    Task<List<Docentes>> GetAll();
    Task<Docentes> GetById(Guid id);
    Task<Docentes> PostAlumno(Docentes docente);
}