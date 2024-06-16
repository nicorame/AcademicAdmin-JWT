namespace Api_AdminAcademic.Dtos;

public class CursosDto
{
    public string Name { get; set; }
    public string Schedules { get; set; }
    public DateTime CreationDate { get; set; }
    public CarrerasDto Carrera { get; set; }
}