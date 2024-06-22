namespace Api_AdminAcademic.Dtos;

public class CursoDtoForListDocente
{
    public string Name { get; set; }
    public List<DocenteDtoForList> Docentes { get; set; }
}