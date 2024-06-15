using Api_AdminAcademic.Data;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_AdminAcademic.Repository;

public class UsuariosRepository : IUsuariosRepository
{
    private readonly ContextDb _contextDb;

    public UsuariosRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Usuarios>> GetAll()
    {
        var usuarios = await _contextDb.Usuarios.ToListAsync();
        return usuarios;
    }

    public async Task<Usuarios> GetById(Guid id)
    {
        var usuario = await _contextDb.Usuarios.FirstOrDefaultAsync(c => c.Id == id);
        return usuario;
    }
}