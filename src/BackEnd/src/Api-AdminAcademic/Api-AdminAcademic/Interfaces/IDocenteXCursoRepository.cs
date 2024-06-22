using Api_AdminAcademic.Models;

namespace Api_AdminAcademic.Interfaces;

public interface IDocenteXCursoRepository
{
    Task<List<DocentesXCursos>> GetAl();
    Task<List<DocentesXCursos>> GetById(Guid id);
    Task<DocentesXCursos> GetByIdDocenteAndIdCurso(Guid idDocente, Guid idCurso);
    Task<DocentesXCursos> PostDocenteXCurso(DocentesXCursos docentesXCursos);
    Task<DocentesXCursos> GetByIdCursoAndIdDocente(Guid idCurso, Guid idDocente);
    Task<DocentesXCursos> DeleteDocenteXCurso(Guid idCurso, Guid idDocente);

}