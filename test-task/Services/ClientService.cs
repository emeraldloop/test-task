using Microsoft.EntityFrameworkCore;
using test_task.Models;
using test_task.Models.Context;

namespace test_task.Services;

public class ClientService : IClientService
{
    private readonly Context _context;

    public ClientService(Context ctx)
    {
        _context = ctx;
    }
    
    public async Task<Client> AddClient(Client client)
    {
        await _context.Clients.AddAsync(client);
        try
        {
            await _context.SaveChangesAsync();
            return client;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: when update db context, reason: {0}", e.InnerException.Message);
            
            throw new DbUpdateException();
        }
    }

    public async Task<List<Client>> GetAllClients()
    {
        return await _context.Clients.ToListAsync();
    }
}