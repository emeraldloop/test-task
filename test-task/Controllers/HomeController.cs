﻿using System.Diagnostics;
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

    public async Task<IActionResult> Index()
    {
        //ViewBag.Types = _ctx.BusinessType.ToList();
        return View( await _clientService.GetAllClients());
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
        ViewBag.Types =new SelectList(_ctx.BusinessType.ToList(), "Id", "Name");
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddClient(long Inn, string Name, int TypeId)
    {
        Client client = new Client(Inn,Name,TypeId);
        await _clientService.AddClient(client);
        return Redirect("~/Home/Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> EditClient(long Inn)
    {
        ViewBag.Types =new SelectList(_ctx.BusinessType.ToList(), "Id", "Name");
        var clientToUpdate = _ctx.Clients.FirstOrDefault(cl => cl.Inn.Equals(Inn));
        return View(clientToUpdate);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditClient(long Inn, string Name, int TypeId)
    {
        Client updatedClient = new Client(Inn, Name, TypeId);
        await _clientService.EditClient(updatedClient);
        return Redirect("~/Home/Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> AddConstitutor(long clientInn)
    {
        ViewData["clientInn"] = clientInn;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddConstitutor(long Inn,long clientInn, string fullName )
    {
        Сonstitutor constitutor = new Сonstitutor(Inn,clientInn,fullName);
        await _constitutorService.AddСonstitutor(constitutor);
        return Redirect($"~/Home/ShowClient/?clientInn={clientInn}");
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
    public async Task<IActionResult> EditСonstitutor(long Inn,long clientInn,string fullName)
    {
        var constitutor = new Сonstitutor(Inn, clientInn, fullName);
        await _constitutorService.EditСonstitutor(constitutor);
        return Redirect($"~/Home/ShowClient/?clientInn={clientInn}");
    }
}