public class ClientModel
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public string Prenom { get; set; }

    public string Email { get; set; }

    public string NumeroTelephone { get; set; }

        public ClientModel(int id, string nom, string email, string numeroTelephone) {
        Id = id;
        Nom = nom;
        Email = email;
        NumeroTelephone = numeroTelephone;
    }
}