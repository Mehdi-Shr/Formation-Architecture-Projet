public class MenageRepository : IMenageRepository
{
    private readonly GestionHotelContext _context;

    public HousekeepingRepository(GestionHotelContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ChambreModel>> GetChambresANettoyerAsync()
    {
        // Logique pour obtenir les chambres à nettoyer
    }

    public async Task MarquerNettoyageAsync(int idChambre)
    {
        // Logique pour marquer une chambre comme nettoyée
    }
}