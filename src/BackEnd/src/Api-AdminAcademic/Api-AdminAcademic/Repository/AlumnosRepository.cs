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

    public async Task<Alumnos> UpdateAlumno(Alumnos alumnos)
    {
        var alumno = await _contextDb.Alumnos
            .Include(c => c.Rol)
            .FirstOrDefaultAsync(c => c.Id == alumnos.Id);

        alumno.Id = alumnos.Id;
        alumno.Name = alumnos.Name;
        alumno.LastName = alumnos.LastName;
        alumno.File = alumnos.File;
        alumno.Rol = alumnos.Rol;

        _contextDb.Update(alumno);
        _contextDb.SaveChanges();

        return alumno;
    }

    public async Task<Alumnos> DeleteAlumno(Guid id)
    {
        var alumno = await _contextDb.Alumnos
            .Include(c => c.Rol)
            .FirstOrDefaultAsync(c => c.Id == id);

        _contextDb.Remove(alumno);
        _contextDb.SaveChanges();
        
        return alumno;
    }
}