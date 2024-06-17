namespace Api_AdminAcademic.Query;

public class NuevoCursoQuery
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Schedules { get; set; }
    public Guid Carrera { get; set; }
}