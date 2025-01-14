﻿using Api_AdminAcademic.Data;
using Api_AdminAcademic.Interfaces;
using Api_AdminAcademic.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_AdminAcademic.Repository;

public class CarrerasRepository : ICarrerasRepository
{
    private readonly ContextDb _contextDb;

    public CarrerasRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Carreras>> GetAll()
    {
        var carreras = await _contextDb.Carreras.ToListAsync();
        return carreras;
    }

    public async Task<Carreras> GetById(Guid id)
    {
        var carrera = await _contextDb.Carreras.FirstOrDefaultAsync(c => c.Id == id);
        return carrera;
    }

    public async Task<Carreras> PostCarreras(Carreras carreras)
    {
        await _contextDb.AddAsync(carreras);
        await _contextDb.SaveChangesAsync();
        return carreras;
    }
}