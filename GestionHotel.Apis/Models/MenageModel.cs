public class MenageModel {
    public int Id { get; private set; }
    public string Nom { get; private set; }

    public MenageModel(int id, string nom) {
        Id = id;
        Nom = nom;
    }
}