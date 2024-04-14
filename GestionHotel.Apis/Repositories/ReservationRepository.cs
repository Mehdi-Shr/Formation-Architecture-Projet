public class ReservationRepository : IReservationRepository
{
    private readonly GestionHotelContext _context;

    public ReservationRepository(GestionHotelContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ReservationModel>> GetReservationsAsync()
    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task<ReservationModel> GetByIdAsync(int id)
    {
        return await _context.Reservations.FindAsync(id);
    }

    public async Task<IEnumerable<ReservationModel>> GetReservationsByClientIdAsync(int clientId)
    {
        return await _context.Reservations.Where(r => r.ClientId == clientId).ToListAsync();
    }

    public async Task<IEnumerable<ReservationModel>> GetReservationsByChambreIdAsync(int chambreId)
    {
        return await _context.Reservations.Where(r => r.ChambreId == chambreId).ToListAsync();
    }

    public async Task AddAsync(ReservationModel reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ReservationModel reservation)
    {
        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> AnnulerReservationAsync(int reservationId, bool remboursement)
    {
        // Logique pour annuler la réservation avec gestion de remboursement
    }
}
