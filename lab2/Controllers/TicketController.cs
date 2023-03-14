using lab2.Models;
using lab2.Models.Domain;
using lab2.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab2.Controllers;

public class TicketController : Controller
{
    public IActionResult Index()
    {
        var ticket = Ticket.GetTicketList();
        return View(ticket);
    }

    // public IActionResult Get(Ticket ticket)
    // {
    //     Ticket.GetTicketList().Add(ticket);
    //     return View("Index", null);
    // }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddTicket ticket)
    {
        //Add the ticket to the list
        var ticketList = Ticket.GetTicketList();
        var ticketToAdd = new Ticket
        {
            CreatedDate = DateTime.Now,
            Description = ticket.Description,
            IsClosed = ticket.IsClosed,
            Severity = ticket.Severity
        };
        ticketList.Add(ticketToAdd);

        return RedirectToAction(nameof(Index)); 
    }
}
