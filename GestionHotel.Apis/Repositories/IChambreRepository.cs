public interface IChambreRepository
{
    Task<ChambreRepository> GetByIdAsync(int id);
    Task<IEnumerable<ChambreRepository>> GetAllAsync();
    Task AddAsync(ChambreRepository chambre);
    Task UpdateAsync(ChambreRepository chambre);
    Task DeleteAsync(int id);
}