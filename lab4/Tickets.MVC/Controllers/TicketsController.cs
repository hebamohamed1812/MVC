using Microsoft.AspNetCore.Mvc;
using Tickets.BL;
using Tickets.BL.ViewModels;

namespace Tickets.MVC.Controllers;
public class TicketsController : Controller
{
    private readonly ITicketsManager _ticketsManager;

    public TicketsController(ITicketsManager ticketsManager)
    {
        _ticketsManager = ticketsManager;
    }

    public IActionResult Index()
    {
        return View(_ticketsManager.GetAll());
    }

    public IActionResult Details(int id)
    {
        var ticket = _ticketsManager.Get(id);
        if (ticket is null)
        {
            View("NotFoundTicket");
        }
        return View(ticket);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(TicketAddVM ticket)
    {
        _ticketsManager.Add(ticket);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var ticketToEdit = _ticketsManager.Get(id);
        if (ticketToEdit is null)
        {
            View("NotFoundTicket");
        }
        var ticketEditVM = new TicketEditVM
        {
            Id = ticketToEdit.Id,
            Title = ticketToEdit.Title,
            Description = ticketToEdit.Description,
            Severity = ticketToEdit.Severity
        };

        return View(ticketEditVM);
    }

    [HttpPost]
    public IActionResult Edit(TicketEditVM ticketVM)
    {
        _ticketsManager.Edit(ticketVM);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(TicketEditVM ticketVM)
    {
        _ticketsManager.Delete(ticketVM);
        return RedirectToAction(nameof(Index));
    }
}
