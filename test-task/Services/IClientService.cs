using test_task.Models;

namespace test_task.Services;

public interface IClientService
{
    public Task<Client> AddClient(Client client);
    public Task<Client> EditClient( Client client);
    public Task<Client> DeleteClient(long clientInn);
    public Task<List<Client>> GetAllClients();
}