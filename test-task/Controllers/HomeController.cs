using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        return View( await _clientService.GetAllClients());
    }

    public async Task<IActionResult> AddClient(long Inn, string name, int type)
    {
        Client client = new Client(Inn,name,type);
        await _clientService.AddClient(client);
        return View();
    }

}