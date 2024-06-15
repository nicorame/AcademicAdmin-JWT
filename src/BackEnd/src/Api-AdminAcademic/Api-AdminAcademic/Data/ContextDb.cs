using Api_AdminAcademic.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_AdminAcademic.Data;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
        
    }
    
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Alumnos> Alumnos { get; set; }
    public DbSet<Docentes> Docentes { get; set; }
    public DbSet<Carreras> Carreras { get; set; }
    public DbSet<Cursos> Cursos { get; set; }
    public DbSet<AlumnosXCursos> AlumnosXCursos { get; set; }
    public DbSet<DocentesXCursos> DocentesXCursos { get; set; }
}