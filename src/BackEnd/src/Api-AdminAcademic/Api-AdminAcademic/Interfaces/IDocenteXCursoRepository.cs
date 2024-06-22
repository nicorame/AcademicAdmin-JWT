using Api_AdminAcademic.Models;

namespace Api_AdminAcademic.Interfaces;

public interface IDocenteXCursoRepository
{
    Task<List<DocentesXCursos>> GetAl();
    Task<List<DocentesXCursos>> GetById(Guid id);
    Task<DocentesXCursos> PostDocenteXCurso(DocentesXCursos docentesXCursos);
    Task<DocentesXCursos> GetByIdCursoAndIdDocente(Guid idCurso, Guid idDocente);

    
}