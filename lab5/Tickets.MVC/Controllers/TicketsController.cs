using Tickets.BL;
using Tickets.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Tickets.MVC.Controllers;

public class TicketsController : Controller
{
    private readonly ITicketsManager _ticketsManager;
    private readonly IDepartmentsManager _departmentsManager;
    private readonly IDevelopersManager _developersManager;

    public TicketsController(ITicketsManager ticketsManager,
        IDepartmentsManager depeartmentsManager,
        IDevelopersManager developersManager)
    {
        _ticketsManager = ticketsManager;
        _departmentsManager = depeartmentsManager;
        _developersManager = developersManager;
    }

    public IActionResult Details(int id)
    {
        var ticketVM = _ticketsManager.GetTicketDetails(id);
        if (ticketVM is null)
        {
            return NotFound();
        }

        return View(ticketVM);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var ticketVM = _ticketsManager.GetForEdit(id);

        ViewBag.Departments = _departmentsManager.GetDepartmentsListItems();
        ViewBag.Developers = _developersManager.GetDevelopersListItems();
        return View(ticketVM);
    }

    [HttpPost]
    public IActionResult Edit(TicketEditVM ticketVM)
    {
        _ticketsManager.Update(ticketVM);
        return RedirectToAction(nameof(Details), new { id = ticketVM.Id });
    }
}
