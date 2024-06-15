using Api_AdminAcademic.Data;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_AdminAcademic.Repository;

public class RolesRepository : IRolesRepository
{
    private readonly ContextDb _contextDb;

    public RolesRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Roles>> GetAll()
    {
        var roles = await _contextDb.Roles.ToListAsync();
        return roles;
    }

    public async Task<Roles> GetById(Guid id)
    {
        var rol = await _contextDb.Roles.FirstOrDefaultAsync(c => c.Id == id);
        return rol;
    }
}