public class Chambre
{
    public int Id { get; set; }

    public string Numero { get; set; }

    public TypeChambre Type { get; set; }

    public int TarifParNuit { get; set; }

    public int NbPersonnesMax { get; set; }

    public bool EstDisponible(DateTime dateDebut, DateTime dateFin)
    {
        // TODO: Implémenter la logique de vérification de disponibilité
        return true;
    }

    public bool EstPropre { get; set; }

    public string EtatGeneral { get; set; }
}

public enum TypeChambre
{
    Simple,
    Double,
    Suite
}