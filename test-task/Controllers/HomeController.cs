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
    private readonly IСonstitutorService _constitutorService;
    
    public HomeController(ILogger<HomeController> logger,Context context,IClientService clientService,IСonstitutorService constitutorService)
    {
        _logger = logger;
        _ctx = context;
        _clientService = clientService;
        _constitutorService = constitutorService;
    }

    /* 
    public async Task<IActionResult> Index()
    {
        return View( await _clientService.GetAllClients());
    }
    */
    
    public async Task<IActionResult> Index(int? businessType, string name, int page = 1, 
        SortState sortOrder = SortState.NameAsc)
    {
        int pageSize = 3;
 
        //фильтрация
        IQueryable<Client> clients = _ctx.Clients;
        if (businessType != null && businessType != 2)
        { 
            clients = clients.Where(p => (int)p.BusinessType == businessType);
        }
        if (!String.IsNullOrEmpty(name))
        {
            clients = clients.Where(p => p.Name.Contains(name));
        }
 
        // сортировка
        switch (sortOrder)
        {
            case SortState.NameDesc:
                clients = clients.OrderByDescending(s => s.Name);
                break;
            case SortState.DateAddAsc:
                clients=clients.OrderBy(s => s.DateAdding);
                break;
            case SortState.DateAddDesc:
                clients = clients.OrderByDescending(s => s.DateAdding);
                break;
            case SortState.DateUpdateAsc:
                clients = clients.OrderBy(s => s.DateUpdating);
                break;
            case SortState.DateUpdateDesc:
                clients = clients.OrderByDescending(s => s.DateUpdating);
                break;
            case SortState.BusinessTypeAsc:
                clients=clients.OrderBy(s => s.BusinessType);
                break;
            case SortState.BusinessTypeDesc:
                clients=clients.OrderByDescending(s => s.BusinessType);
                break;
            default:
                clients = clients.OrderBy(s => s.Name);
                break;
        }
 
        // пагинация
        var count = await clients.CountAsync();
        var items = await clients.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
 

        
        // формируем модель представления
        IndexViewModel viewModel = new IndexViewModel 
        {
            PageViewModel = new PageViewModel(count, page, pageSize),
            SortViewModel = new SortViewModel(sortOrder),
            FilterViewModel = new FilterViewModel(businessType, name), 
            Clients = items
        };
        return View(viewModel);
    }    
    
    public async Task<IActionResult> ShowClient(long clientInn)
    {
        Client client = _ctx.Clients.FirstOrDefault(c => c.Inn.Equals(clientInn));
        client.Сonstitutors = await _ctx.Сonstitutors.Where(cos => cos.ClientInn.Equals(client.Inn)).ToListAsync();
        return View(client);
    }
    
    [HttpGet]
    public async Task<IActionResult> AddClient()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddClient(Client client)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _clientService.AddClient(client);
                return Redirect("~/Home/Index");
            }
            else return View(client);
        }
        catch (Exception ex)
        {
            _logger.LogWarning("An error while execute client adding request, reason: {0}",ex.Message);
            return Redirect($"~/Home/Error/?message={ex.Message}");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> EditClient(long Inn)
    {
        var clientToUpdate = _ctx.Clients.FirstOrDefault(cl => cl.Inn.Equals(Inn));
        return View(clientToUpdate);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditClient(Client client)
    {
        await _clientService.EditClient(client);
        return Redirect("~/Home/Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> AddСonstitutor(long clientInn)
    {
        ViewData["clientInn"] = clientInn;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddСonstitutor(Сonstitutor constitutor)
    {
        try
        {
            var client = _ctx.Clients.FirstOrDefault(cl => cl.Inn.Equals(constitutor.ClientInn));
            if (ModelState.IsValid && client.BusinessType != 1)
            {
                await _constitutorService.AddСonstitutor(constitutor);
                return Redirect($"~/Home/ShowClient/?clientInn={constitutor.ClientInn}");
            }
            else return View(constitutor);
        }
        catch(Exception ex)
        {
            _logger.LogWarning("An error while execute client adding request, reason: {0}",ex.Message);
            return Redirect($"~/Home/Error/?message={ex.Message}");
        }
        
    }
    
    public async Task<IActionResult> DeleteClient(long clientInn)
    {
        await _clientService.DeleteClient(clientInn);
        return Redirect($"~/Home/Index");
    }
    
    public async Task<IActionResult> DeleteСonstitutor(long clientInn,long constitutorInn)
    {
        await _constitutorService.DeleteСonstitutor(constitutorInn);
        return Redirect($"~/Home/ShowClient/?clientInn={clientInn}");
    }

    [HttpGet]
    public async Task<IActionResult> EditСonstitutor(long Inn)
    {
        var constitutorToUpdate = _ctx.Сonstitutors.FirstOrDefault(co => co.Inn.Equals(Inn));
        return View(constitutorToUpdate);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditСonstitutor(Сonstitutor сonstitutor)
    {
        await _constitutorService.EditСonstitutor(сonstitutor);
        return Redirect($"~/Home/ShowClient/?clientInn={сonstitutor.ClientInn}");
    }

    public async Task<IActionResult> Error(string message)
    {
        ViewData["message"] = message;
        return View();
    }
}