public class ReservationRepository : IReservationRepository
{
    private readonly GestionHotelContext _context;

    public ReservationRepository(GestionHotelContext context)
    {
        _context = context;
    }

    public async Task<Reservation> GetByIdAsync(int id)
    {
        return await _context.Reservations.FindAsync(id);
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task AddAsync(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Reservation reservation)
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

    public async Task<IEnumerable<Reservation>> GetReservationsByClientId(int clientId)
    {
        return await _context.Reservations.Where(r => r.ClientId == clientId).ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetReservationsByChambreId(int chambreId)
    {
        return await _context.Reservations.Where(r => r.ChambreId == chambreId).ToListAsync();
    }

    public async Task<bool> AnnulerReservationAsync(int reservationId)
    {
        var reservation = await _context.Reservations.FindAsync(reservationId);
        if (reservation != null)
        {
            // TODO: Implémenter la logique d'annulation de la réservation
            return true;
        }

        return false;
    }
}