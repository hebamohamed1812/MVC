namespace Tickets.DAL;

public interface ITicketsRepo
{
    IEnumerable<Ticket> GetAll();
    Ticket? Get(int id);
    void Add(Ticket ticket);
    void Update(Ticket ticket);
    void Delete(int id);
    int SaveChanges();
}