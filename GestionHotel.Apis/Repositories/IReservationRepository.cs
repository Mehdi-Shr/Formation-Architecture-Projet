public interface IReservationRepository
{
    Task<ReservationRepository> GetByIdAsync(int id);
    Task<IEnumerable<ReservationRepository>> GetAllAsync();
    Task AddAsync(ReservationRepository reservation);
    Task UpdateAsync(ReservationRepository reservation);
    Task DeleteAsync(int id);
    Task<IEnumerable<ReservationRepository>> GetReservationsByClientId(int clientId);
    Task<IEnumerable<ReservationRepository>> GetReservationsByChambreId(int chambreId);
    Task<bool> AnnulerReservationAsync(int reservationId);
}