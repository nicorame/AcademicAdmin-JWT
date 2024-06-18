namespace Api_AdminAcademic.Query;

public class NuevoAlumnoQuery
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string File { get; set; }
    public Guid Rol { get; set; }
}