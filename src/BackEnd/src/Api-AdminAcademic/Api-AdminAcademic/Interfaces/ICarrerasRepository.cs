using Api_AdminAcademic.Models;

namespace Api_AdminAcademic.Interfaces;

public interface ICarrerasRepository
{
    Task<List<Carreras>> GetAll();
    Task<Carreras> GetById(Guid id);
    Task<Carreras> PostCarreras(Carreras carreras);
}