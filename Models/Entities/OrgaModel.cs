namespace C_Hero.Models.Entities
{
    public class OrgaModel
    {
        public Guid PK_Orga { get; set; }
        public DateTime Creation { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Name { get; set; }
        public string? Social_Siege { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Comment { get; set; }
        public string? Picture { get; set; }
        public int Nb_Incident_Declared { get; set; }

        // Collections pour les relations many-to-many
        public ICollection<CivilModel> Members { get; set; }
        public ICollection<CivilModel> Dirigeant { get; set; }

        // Collections pour les héros et les vilains
        public ICollection<SuperHeroModel> Heroes { get; set; }
        public ICollection<SuperVillainModel> Villains { get; set; }

        public OrgaModel()
        {
            Members = new List<CivilModel>();
            Dirigeant = new List<CivilModel>();
            Heroes = new List<SuperHeroModel>();
            Villains = new List<SuperVillainModel>();
        }

        public OrgaModel(DateTime lastUpdate,
            string name, string? social_siege,
            string? cellPhone, string? email,
            string? picture)
        {
            PK_Orga = Guid.NewGuid();
            Creation = DateTime.Now;
            LastUpdate = Creation;
            Name = name;
            Social_Siege = social_siege;
            Phone = cellPhone;
            Email = email;
            Picture = picture;
            Nb_Incident_Declared = 0;
            Members = new List<CivilModel>();
            Dirigeant = new List<CivilModel>();
            Heroes = new List<SuperHeroModel>();
            Villains = new List<SuperVillainModel>();
        }
    }
}
