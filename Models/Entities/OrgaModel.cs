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
        public ICollection<CivilModel> Members { get; set; }
        public ICollection<CivilModel> Dirigeant { get; set; }
        public ICollection<SuperHeroModel> Heroes { get; set; }
        public ICollection<SuperVillainModel> Villains { get; set; }

        public OrgaModel()
        {
            Name = string.Empty;
            Members = new List<CivilModel>();
            Dirigeant = new List<CivilModel>();
            Heroes = new List<SuperHeroModel>();
            Villains = new List<SuperVillainModel>();
        }
    }
}
