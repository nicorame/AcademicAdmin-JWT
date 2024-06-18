using Api_AdminAcademic.Data;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Models;
using Api_AdminAcademic.Query;
using Api_AdminAcademic.Response;
using Microsoft.EntityFrameworkCore;

namespace Api_AdminAcademic.Repository;

public class AlumnosRepository : IAlumnosRepository
{
    private readonly ContextDb _contextDb;

    public AlumnosRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<List<Alumnos>> GetAll()
    {
        var alumnos = await _contextDb.Alumnos
            .Include(c => c.Rol)
            .ToListAsync();
        return alumnos;
    }

    public async Task<Alumnos> GetById(Guid id)
    {
        var alumno = await _contextDb.Alumnos
            .Include(c => c.Rol)
            .FirstOrDefaultAsync(c => c.Id == id);
        return alumno;
    }

    public async Task<Alumnos> PostAlumno(Alumnos alumnos)
    {
        await _contextDb.AddAsync(alumnos);
        await _contextDb.SaveChangesAsync();
        return alumnos;
    }
}