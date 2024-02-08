namespace GestionHotel.Apis.Endpoints.Booking;

public class BookingInput
{
    public int ClientId { get; set; }
    public int ChambreId { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
    public int Montant { get; set; }
    public string PaiementId { get; set; }
}