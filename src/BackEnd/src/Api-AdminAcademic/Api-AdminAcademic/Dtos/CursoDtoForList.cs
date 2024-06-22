namespace Api_AdminAcademic.Dtos;

public class CursoDtoForList
{
    public string Name { get; set; }
    public List<AlumnoDtoForList> Alumnos { get; set; }
}