namespace Api_AdminAcademic.Dtos;

public class CursoDtoForList
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<AlumnoDtoForList> Alumnos { get; set; }
}