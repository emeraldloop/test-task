using Microsoft.EntityFrameworkCore;
using test_task.Models;
using test_task.Models.Context;

namespace test_task.Services;

public class ClientService : IClientService
{
    private readonly Context _context;
    private readonly ILogger<ClientService> _logger;
    private readonly IСonstitutorService _сonstitutorService;
    public ClientService(Context ctx,IСonstitutorService сonstitutorService)
    {
        _сonstitutorService = сonstitutorService;
        _context = ctx;
    }
    
    public async Task<Client> AddClient(Client client)
    {
        try
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }
        catch (Exception e)
        {
            _logger.LogWarning("Error: when update db context, reason: {0}", e.InnerException.Message);
            throw new DbUpdateException();
        }
        
    }

    public async Task<Client> EditClient(Client client)
    {
        var entity = await _context.Clients.FirstOrDefaultAsync(c => c.Inn.Equals(client.Inn));
        if (entity != null)
        {
            entity.Name = client.Name;
            entity.BusinessType = client.BusinessType;
            entity.Сonstitutors = await _context.Сonstitutors.Where(cos => cos.ClientInn.Equals(client.Inn)).ToListAsync();
            if (entity.BusinessType == 1)
            {
                List<long> consInn = new List<long>();
                foreach (var cl in _context.Сonstitutors)
                {
                    if (cl.ClientInn == entity.Inn) 
                        consInn.Add(cl.Inn);
                }
                foreach (var Inn in consInn)
                {
                    await _сonstitutorService.DeleteСonstitutor(Inn);
                }
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
            _logger.LogWarning("Error: when update db context, reason: {0}", e.InnerException.Message);
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