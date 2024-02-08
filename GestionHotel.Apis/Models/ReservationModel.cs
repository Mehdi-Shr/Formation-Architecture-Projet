public class Reservation
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int ChambreId { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public int Montant { get; set; }

    public string PaiementId { get; set; }

    public Client Client { get; set; }

    public Chambre Chambre { get; set; }

    public bool EstAnnulableAvecRemboursement()
    {
        // TODO: Implémenter la logique de vérification de l'annulation avec remboursement
        return true;
    }
}