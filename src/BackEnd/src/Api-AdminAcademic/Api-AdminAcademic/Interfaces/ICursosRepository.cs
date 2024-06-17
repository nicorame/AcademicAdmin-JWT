using Api_AdminAcademic.Models;

namespace Api_AdminAcademic.Interfaces;

public interface ICursosRepository
{
    Task<List<Cursos>> GetAll();
    Task<Cursos> GetById(Guid id);
    Task<Cursos> PostCursos(Cursos curso);
}