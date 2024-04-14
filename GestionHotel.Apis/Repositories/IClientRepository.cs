public interface IClientRepository
{
    Task<ClientRepository> GetByIdAsync(int id);
    Task<IEnumerable<ClientRepository>> GetAllAsync();
    Task AddAsync(ClientRepository client);
    Task UpdateAsync(ClientRepository client);
    Task DeleteAsync(int id);
}