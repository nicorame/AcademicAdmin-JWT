using System.ComponentModel.DataAnnotations.Schema;

namespace Api_AdminAcademic.Models;

[Table("roles")]
public class Roles
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}