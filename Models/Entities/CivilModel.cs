namespace C_Hero.Models.Entities
{
    public class CivilModel
    {
        public Guid PK_Civil { get; set; }
        public DateTime Creation { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Civility { get; set; }
        public string? Address { get; set; }
        public string? CellPhone { get; set; }
        public string? Email { get; set; }
        public string? Nationality { get; set; }
        public string? Comment { get; set; }
        public string? Picture { get; set; }
        public int Nb_Incident_Declared { get; set; }
        public int Nb_Time_Being_Victim { get; set; }
        public ICollection<OrgaModel> Orgas { get; set; } = new List<OrgaModel>();
        public ICollection<OrgaModel> DirigeantOrgas { get; set; } = new List<OrgaModel>();

        public CivilModel()
        {
            Orgas = new List<OrgaModel>();
            DirigeantOrgas = new List<OrgaModel>();
        }
    }
}
