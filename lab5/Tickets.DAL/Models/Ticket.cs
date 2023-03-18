using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tickets.DAL;
public class Ticket
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
}