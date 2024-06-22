using Api_AdminAcademic.Data;
using Api_AdminAcademic.Dtos;
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

    public async Task<List<AlumnosXCursos>> GetAll()
    {
        var alumnoXcurso = await _contextDb.AlumnosXCursos
            .Include(a => a.Alumno)
            .Include(a => a.Curso)
            .ToListAsync();
        return alumnoXcurso;
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

    public async Task<AlumnosXCursos> GetAlumnoByIdAndIdCurso(Guid idAlumno, Guid idCurso)
    {
        var alumnoXcurso = await _contextDb.AlumnosXCursos
            .Include(a => a.Alumno)
            .Include(a => a.Curso)
            .FirstOrDefaultAsync(a => a.IdAlumno == idAlumno && a.IdCurso == idCurso);

        return alumnoXcurso;
    }

    public async Task<AlumnosXCursos> PostAlumnoXCurso(AlumnosXCursos alumnosXCursos)
    {
        await _contextDb.AddAsync(alumnosXCursos);
        await _contextDb.SaveChangesAsync();
        return alumnosXCursos;
    }
    
    public async Task<bool> IsAlumnoInCurso(Guid idCurso, Guid idAlumno)
    {
        return await _contextDb.AlumnosXCursos
            .AnyAsync(a => a.IdCurso == idCurso && a.IdAlumno == idAlumno);
    }

    public async Task<AlumnosXCursos> DeleteAlumno(Guid idAlumno, Guid idCurso)
    {
        var alumnoXcurso = await _contextDb.AlumnosXCursos
            .Include(a => a.Alumno)
            .Include(a => a.Curso)
            .FirstOrDefaultAsync(a => a.IdAlumno == idAlumno && a.IdCurso ==idCurso);

        _contextDb.Remove(alumnoXcurso);
        await _contextDb.SaveChangesAsync();
        return alumnoXcurso;
    }
}