using Api_AdminAcademic.Dtos;
using Api_AdminAcademic.Models;

namespace Api_AdminAcademic.Interfaces;

public interface IAlumnosXCursosRepository
{
    Task<List<AlumnosXCursos>> GetAll();

    Task<List<AlumnosXCursos>> GetByCurso(Guid id);
}