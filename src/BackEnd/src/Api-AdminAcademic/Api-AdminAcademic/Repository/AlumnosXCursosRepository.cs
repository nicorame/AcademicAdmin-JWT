using Api_AdminAcademic.Data;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_AdminAcademic.Repository;

public class AlumnosXCursosRepository : IAlumnosXCursosRepository
{
    private readonly ContextDb _contextDb;

    public AlumnosXCursosRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<AlumnosXCursos>> GetByCurso(Guid id)
    {
        var alumnoXcurso = await _contextDb.AlumnosXCursos
            .Include(a => a.Alumno)
            .Include(a => a.Curso)
            .Where(a => a.IdCurso == id)
            .ToListAsync();
        return alumnoXcurso;
    }
}