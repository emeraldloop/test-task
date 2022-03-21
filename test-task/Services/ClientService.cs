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

    public async Task<Client> EditClient(Client client)
    {
        var entity = await _context.Clients.FirstOrDefaultAsync(c => c.Inn.Equals(client.Inn));
        if (entity != null)
        {
            entity.Name = client.Name;
            entity.BusinessTypeId = client.BusinessTypeId;
            if (entity.BusinessTypeId == 1)
            {
                entity.Сonstitutors = null;
            }
            entity.DateUpdating = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
        }

        try
        {
            _context.Clients.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: when update db context, reason: {0}", e.InnerException.Message);
            
            throw new DbUpdateException();
        }

    }

    public async Task<Client> DeleteClient(long clientInn)
    {
        var client =await _context.Clients.FirstOrDefaultAsync(cl => cl.Inn.Equals(clientInn));
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<List<Client>> GetAllClients()
    {
        return await _context.Clients.ToListAsync();
    }
    
    
}