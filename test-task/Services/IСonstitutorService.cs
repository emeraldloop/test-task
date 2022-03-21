using test_task.Models;

namespace test_task.Services;

public interface IСonstitutorService
{
    public Task<Сonstitutor> AddСonstitutor(Сonstitutor constitutor);
    public Task<Сonstitutor> DeleteСonstitutor(long Inn);
    public Task<Сonstitutor> EditСonstitutor(Сonstitutor constitutor);
    public Task<List<Сonstitutor>> GetAllClientСonstitutors(long constitutorInn);
}