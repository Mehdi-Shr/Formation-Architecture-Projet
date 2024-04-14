public class ChambreRepository : IChambreRepository
{
    private readonly GestionHotelContext _context;

    public ChambreRepository(GestionHotelContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ChambreModel>> GetChambresDisponiblesAsync(DateTime dateDebut, DateTime dateFin)
    {
        // Logique pour obtenir les chambres disponibles pour les dates spécifiées
    }

    public async Task<ChambreModel> GetByIdAsync(int id)
    {
        return await _context.Chambres.FindAsync(id);
    }

    public async Task<IEnumerable<ChambreModel>> GetAllAsync()
    {
        return await _context.Chambres.ToListAsync();
    }

    public async Task AddAsync(ChambreModel chambre)
    {
        _context.Chambres.Add(chambre);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ChambreModel chambre)
    {
        _context.Chambres.Update(chambre);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var chambre = await _context.Chambres.FindAsync(id);
        if (chambre != null)
        {
            _context.Chambres.Remove(chambre);
            await _context.SaveChangesAsync();
        }
    }
}
