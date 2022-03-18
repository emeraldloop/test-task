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
        await _context.Сonstitutors.AddAsync(constitutor);
        try
        {
            await _context.SaveChangesAsync();
            return constitutor;
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