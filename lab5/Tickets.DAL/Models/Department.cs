using System.ComponentModel.DataAnnotations;
namespace Tickets.DAL;
public class Department
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
}