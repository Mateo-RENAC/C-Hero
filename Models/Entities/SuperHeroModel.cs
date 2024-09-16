using Azure.Identity;

namespace C_Hero.Models.Entities
{
    public class SuperHeroModel
    {
        public Guid PK_SuperH { get; set; }
        public string? Name { get; set; }
        public string? Power { get; set; }
        public string? Weakness { get; set; }
        public string? Picture { get; set; }
        public string? Comment { get; set; }
        public int Nb_Incident_Solved { get; set; }
        public int Score { get; set; }

        // Propriété pour l'identité secrète
        public Guid? SecretIdentityId { get; set; }
        public CivilModel? SecretIdentity { get; set; }

        // Constructeur par défaut
        public SuperHeroModel()
        {
            PK_SuperH = Guid.NewGuid();
            Nb_Incident_Solved = 0;
            Score = 0;
        }

        // Constructeur paramétré
        public SuperHeroModel(string? name, string? power, string? weakness, string? picture, string? comment, CivilModel? secretIdentity = null)
        {
            PK_SuperH = Guid.NewGuid();
            Name = name;
            Power = power;
            Weakness = weakness;
            Picture = picture;
            Comment = comment;
            Nb_Incident_Solved = 0;
            Score = 0;
            SecretIdentity = secretIdentity;
            SecretIdentityId = secretIdentity?.PK_Civil;
        }
    }
}
