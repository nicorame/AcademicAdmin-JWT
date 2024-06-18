using Api_AdminAcademic.Data;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_AdminAcademic.Repository;

public class CursosRepository : ICursosRepository
{
    private readonly ContextDb _contextDb;

    public CursosRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Cursos>> GetAll()
    {
        var cursos = await _contextDb.Cursos
            .Include(c => c.Carrera)
            .ToListAsync();
        return cursos;
    }

    public async Task<Cursos> GetById(Guid id)
    {
        var curso = await _contextDb.Cursos
            .Include(c => c.Carrera)
            .FirstOrDefaultAsync(c => c.Id == id);
        return curso;
    }

    public async Task<Cursos> PostCursos(Cursos curso)
    {
        await _contextDb.AddAsync(curso);
        await _contextDb.SaveChangesAsync();
        return curso;
    }

    public async Task<Cursos> UpdateCursos(Cursos cursos)
    {
        var curso = await _contextDb.Cursos
            .Include(c => c.Carrera)
            .FirstOrDefaultAsync(c => c.Id == cursos.Id);

        
        curso.Id = cursos.Id;
        curso.Name = cursos.Name;
        curso.CreationDate = cursos.CreationDate;
        curso.Schedules = cursos.Schedules;
        curso.Carrera = cursos.Carrera;

        _contextDb.Update(curso);
        _contextDb.SaveChanges();

        return curso;
    }

    public async Task<Cursos> DeleteCursos(Guid id)
    {
        var curso = await _contextDb.Cursos
            .Include(c => c.Carrera)
            .FirstOrDefaultAsync(c => c.Id == id);

        _contextDb.Remove(curso);
        _contextDb.SaveChanges();
        return curso;
    }
}