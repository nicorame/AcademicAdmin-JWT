using Api_AdminAcademic.Models;

namespace Api_AdminAcademic.Interfaces;

public interface IUsuariosRepository
{
    Task<List<Usuarios>> GetAll();
    Task<Usuarios> GetById(Guid id);
}