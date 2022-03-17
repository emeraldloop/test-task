using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test_task.Models;
using test_task.Models.Context;

namespace test_task.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Context _ctx;

    public HomeController(ILogger<HomeController> logger,Context context)
    {
        _logger = logger;
        _ctx = context;

    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
}