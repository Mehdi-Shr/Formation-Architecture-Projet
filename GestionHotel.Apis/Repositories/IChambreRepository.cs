public interface IChambreRepository
{
    Task<Chambre> GetByIdAsync(int id);
    Task<IEnumerable<Chambre>> GetAllAsync();
    Task AddAsync(Chambre chambre);
    Task UpdateAsync(Chambre chambre);
    Task DeleteAsync(int id);
}