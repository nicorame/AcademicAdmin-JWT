using Api_AdminAcademic.Data;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_AdminAcademic.Repository;

public class DocentesRepository : IDocentesRepository
{
    private readonly ContextDb _contextDb;

    public DocentesRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Docentes>> GetAll()
    {
        var docentes = await _contextDb.Docentes
            .Include(c => c.Rol)
            .ToListAsync();
        return docentes;
    }

    public async Task<Docentes> GetById(Guid id)
    {
        var docentes = await _contextDb.Docentes
            .Include(c => c.Rol)
            .FirstOrDefaultAsync(c => c.Id == id);
        return docentes;
    }

    public async Task<Models.Docentes> PostAlumno(Docentes docente)
    {
        await _contextDb.AddAsync(docente);
        await _contextDb.SaveChangesAsync();
        return docente;
    }

    public async Task<Docentes> UpdateDocentes(Docentes docente)
    {
        throw new NotImplementedException();
    }

    public async Task<Docentes> DeleteDocentes(Guid id)
    {
        throw new NotImplementedException();
    }
}