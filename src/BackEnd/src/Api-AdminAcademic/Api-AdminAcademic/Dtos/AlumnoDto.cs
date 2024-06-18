namespace Api_AdminAcademic.Dtos;

public class AlumnoDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string File { get; set; }
    public RolesDto Rol { get; set; }
}