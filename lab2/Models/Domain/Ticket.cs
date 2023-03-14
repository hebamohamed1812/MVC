namespace lab2.Models.Domain;
public class Ticket
{
    public DateTime CreatedDate { get; set; }
	public bool IsClosed { get; set; }
    public string? Description { get; set; } = string.Empty;
	public Severity Severity { get; set; }

    public Ticket()
    {
        CreatedDate = DateTime.Now;
    }
	
    private static readonly List<Ticket> ticket = new List<Ticket>();

	public static List<Ticket> GetTicketList() => ticket;
}


