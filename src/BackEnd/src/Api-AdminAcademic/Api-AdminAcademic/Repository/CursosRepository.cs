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
}