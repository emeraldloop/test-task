using test_task.Models;

namespace test_task.Services;

public interface IClientService
{
    public Task<Client> AddClient(Client client);
    public Task<List<Client>> GetAllClients();
}