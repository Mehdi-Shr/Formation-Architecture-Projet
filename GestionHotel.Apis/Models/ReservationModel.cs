public class ReservationModel
{
    public int Id { get; private set; }
    public ClientModel Client { get; private set; }
    public ChambreModel Chambre { get; private set; }
    public DateTime DateDebut { get; private set; }
    public DateTime DateFin { get; private set; }
    public bool EstAnnulee { get; private set; }

    public ReservationModel(int id, ClientModel client, ChambreModel chambre, DateTime dateDebut, DateTime dateFin) {
        Id = id;
        Client = client;
        Chambre = chambre;
        DateDebut = dateDebut;
        DateFin = dateFin;
        EstAnnulee = false; // Par défaut, une réservation n'est pas annulée
    }

    // Méthodes pour annuler la réservation, calculer les frais, etc.
}