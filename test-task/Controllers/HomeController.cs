using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test_task.Models;
using test_task.Models.Context;
using test_task.Services;

namespace test_task.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Context _ctx;
    private readonly IClientService _clientService;

    public HomeController(ILogger<HomeController> logger,Context context,IClientService clientService)
    {
        _logger = logger;
        _ctx = context;
        _clientService = clientService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Types = _ctx.BusinessType.ToList();
        return View( await _clientService.GetAllClients());
    }
    
    [HttpGet]
    public async Task<IActionResult> AddClient()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddClient(long Inn, string Name, int TypeId)
    {
        Client client = new Client(Inn,Name,TypeId);
        await _clientService.AddClient(client);
        return Redirect("~/Home/Index");
    }

    
}