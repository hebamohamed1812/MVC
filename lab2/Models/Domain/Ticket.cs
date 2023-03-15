using System.Text.Json;
namespace lab2.Models.Domain;
public class Ticket
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsClosed { get; set; }
    public Severity Severity { get; set; }
    public Department? Department { get; set; }
    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();

     public Ticket()
    {
        Id = Guid.NewGuid();
    }
	
    private static readonly List<Ticket> ticket = new List<Ticket>();

	public static List<Ticket> GetTickets() => ticket;
}