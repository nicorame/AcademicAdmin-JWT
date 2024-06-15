using Api_AdminAcademic.Models;

namespace Api_AdminAcademic.Interfaces;

public interface IRolesRepository
{
    Task<List<Roles>> GetAll();
    Task<Roles> GetById(Guid id);
}