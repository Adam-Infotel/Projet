namespace BackEnd.Models {
    public class PersonneModel {
        public string Prenom { get; set; }
        public int Id {get;set;}
        public string Nom { get; set; }
        public string Email { get; set; }
        public string? Telephone { get; set; }
        public string? Adresse { get; set; }
        public string? Ville { get; set; }
        public string? CodePostal { get; set; }
        public string? Pays { get; set; }
        public bool IsConnected { get; set; }
        public DateTime? LastConnexion { get; set; }

        // Constructor simplifié pour mapper facilement une entité Personne à PersonneModel
        public PersonneModel(int id, string prenom, string nom, string email, string? telephone, 
                             string? adresse, string? ville, string? codePostal, string? pays,
                              bool isConnected, DateTime? lastConnexion)
        {
            Id = id;
            Prenom = prenom;
            Nom = nom;
            Email = email;
            Telephone = telephone;
            Adresse = adresse;
            Ville = ville;
            CodePostal = codePostal;
            Pays = pays;
            IsConnected = isConnected;
            LastConnexion = lastConnexion;
        }
    }
}