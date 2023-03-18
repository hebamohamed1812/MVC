namespace Tickets.DAL;

public interface ITicketsRepo
{
    Ticket? GetTicketWithDevelopersAndDepartment(int id);
    Ticket? GetPatientWithDeveloper(int id);
    void Save();
    void Update(Ticket ticket);
}