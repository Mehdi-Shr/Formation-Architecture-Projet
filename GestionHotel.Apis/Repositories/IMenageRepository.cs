public interface IMenageRepository
{
    Task<IEnumerable<ChambreModel>> GetChambresANettoyerAsync();
    Task MarquerNettoyageAsync(int idChambre);
}
