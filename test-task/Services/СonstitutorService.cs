using Microsoft.EntityFrameworkCore;
using test_task.Models;
using test_task.Models.Context;

namespace test_task.Services;

public class СonstitutorService : IСonstitutorService
{
    private readonly Context _context;

    public СonstitutorService(Context ctx)
    {
        _context = ctx;
    }
    
    public async Task<Сonstitutor> AddСonstitutor(Сonstitutor constitutor)
    {
        var cons = constitutor;
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Inn.Equals(constitutor.ClientInn));
        client.DateUpdating = DateTimeOffset.Now.ToUnixTimeSeconds();
        client.Сonstitutors.Add(cons);
        cons.Client = client;
        
        _context.Сonstitutors.Add(cons);
        try
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return constitutor;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: when update db context, reason: {0}", e.InnerException.Message);
            
            throw new DbUpdateException();
        } 
    }

    public async Task<Сonstitutor> DeleteСonstitutor(long Inn)
    {
        var constitutor = await _context.Сonstitutors.FirstOrDefaultAsync(co => co.Inn.Equals(Inn));
        _context.Сonstitutors.Remove(constitutor);
        await _context.SaveChangesAsync();
        return constitutor;
    }

    public async Task<Сonstitutor> EditСonstitutor(Сonstitutor constitutor)
    {
        var entity = await _context.Сonstitutors.FirstOrDefaultAsync(co => co.Inn.Equals(constitutor.Inn));
        if (entity != null)
        {
            entity.FullName = constitutor.FullName;
            entity.DateUpdating = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
        }

        try
        {
            _context.Сonstitutors.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: when update db context, reason: {0}", e.InnerException.Message);
            
            throw new DbUpdateException();
        }
    }

    public async Task<List<Сonstitutor>> GetAllClientСonstitutors(long clientInn)
    {
        return await _context.Сonstitutors.Where(c => c.ClientInn.Equals(clientInn)).ToListAsync();
    }
}