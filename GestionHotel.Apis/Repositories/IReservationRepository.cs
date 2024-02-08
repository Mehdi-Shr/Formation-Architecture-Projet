public interface IReservationRepository
{
    Task<Reservation> GetByIdAsync(int id);
    Task<IEnumerable<Reservation>> GetAllAsync();
    Task AddAsync(Reservation reservation);
    Task UpdateAsync(Reservation reservation);
    Task DeleteAsync(int id);
    Task<IEnumerable<Reservation>> GetReservationsByClientId(int clientId);
    Task<IEnumerable<Reservation>> GetReservationsByChambreId(int chambreId);
    Task<bool> AnnulerReservationAsync(int reservationId);
}