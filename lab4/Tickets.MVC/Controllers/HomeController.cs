using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab4.Models;
using Tickets.DAL;
using Tickets.BL;

namespace lab4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITicketsManager _ticketsManager;
    private readonly ITicketsRepo _ticketsRepo;

    public HomeController(ILogger<HomeController> logger, ITicketsManager ticketsManager, ITicketsRepo ticketsRepo)
    {
        _ticketsManager = ticketsManager;
        _ticketsRepo = ticketsRepo;
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogCritical($"From Controller: {_ticketsRepo.GetHashCode()}");
        _logger.LogCritical($"From Manager: {_ticketsManager.GetRepoHashCode()}");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
