using Azure.Identity;

namespace C_Hero.Models.Entities
{
    public class SuperVillainModel
    {
        public Guid PK_SuperV { get; set; }
        public string? Name { get; set; }
        public string? Power { get; set; }
        public string? Weakness { get; set; }
        public string? Picture { get; set; }
        public string? Comment { get; set; }
        public int Nb_Incident_Caused { get; set; }
        public int Score { get; set; }

        // Propriété pour l'identité secrète
        public Guid? IdentityId { get; set; }
        public CivilModel? Identity { get; set; }

        // Constructeur par défaut
        public SuperVillainModel()
        {
            PK_SuperV = Guid.NewGuid();
            Nb_Incident_Caused= 0;
            Score = 0;
        }

        // Constructeur paramétré
        public SuperVillainModel(string? name, string? power, string? weakness, string? picture, string? comment, CivilModel? secretIdentity = null)
        {
            PK_SuperV = Guid.NewGuid();
            Name = name;
            Power = power;
            Weakness = weakness;
            Picture = picture;
            Comment = comment;
            Nb_Incident_Caused = 0;
            Score = 0;
            Identity = secretIdentity;
            IdentityId = secretIdentity?.PK_Civil;
        }
    }
}
