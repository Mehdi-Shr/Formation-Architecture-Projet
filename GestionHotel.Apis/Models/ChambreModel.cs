public class ChambreModel {
    public int Numero { get; private set; }
    public bool EstDisponible { get; private set; }
    public decimal Tarif { get; private set; }
    public int Capacite { get; private set; }
    public TypeChambre Type { get; private set; }
    public EtatChambre Etat { get; private set; }

    public ChambreModel(int numero, decimal tarif, int capacite, TypeChambre type) {
        Numero = numero;
        Tarif = tarif;
        Capacite = capacite;
        Type = type;
        EstDisponible = true;
        Etat = EtatChambre.Neuf; // Par défaut, une chambre est considérée comme neuve
    }

    // Méthodes pour changer l'état de la chambre, par exemple MarquerCommeNettoyee(), etc.
}

public enum TypeChambre {
    Simple,
    Double,
    Suite
}

public enum EtatChambre {
    Neuf,
    Refaite,
    ARefaire,
    RienASignaler,
    GrosDegats
}