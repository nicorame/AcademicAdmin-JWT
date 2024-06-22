using Api_AdminAcademic.Data;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_AdminAcademic.Repository;

public class DocenteXCursoRepository : IDocenteXCursoRepository
{
    private readonly ContextDb _contextDb;

    public DocenteXCursoRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<DocentesXCursos>> GetAl()
    {
        var docenteXcurso = await _contextDb.DocentesXCursos
            .Include(d => d.Curso)
            .Include(d => d.Docente)
            .ToListAsync();
        return docenteXcurso;
    }

    public async Task<List<DocentesXCursos>> GetById(Guid id)
    {
        var docenteXcurso = await _contextDb.DocentesXCursos
            .Include(d => d.Curso)
            .Include(d => d.Docente)
            .Where(a => a.IdCurso == id)
            .ToListAsync();
        return docenteXcurso;
    }

    public async Task<DocentesXCursos> PostDocenteXCurso(DocentesXCursos docentesXCursos)
    {
        await _contextDb.AddAsync(docentesXCursos);
        await _contextDb.SaveChangesAsync();
        return docentesXCursos;
    }

    public async Task<DocentesXCursos> GetByIdCursoAndIdDocente(Guid idCurso, Guid idDocente)
    {
        var docenteXcurso = await _contextDb.DocentesXCursos
            .Include(d => d.Curso)
            .Include(d => d.Docente)
            .FirstOrDefaultAsync(d => d.IdCurso == idCurso && d.IdDocente == idDocente);
        return docenteXcurso;
    }
}