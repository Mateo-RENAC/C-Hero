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

        // Collection pour la relation Many-to-Many
        public ICollection<OrgaModel> Orgas { get; set; }

        public CivilModel()
        {
            Orgas = new List<OrgaModel>();
        }

        public CivilModel(DateTime lastUpdate,
            DateTime birthDate, DateTime? deathDate,
            string firstName, string lastName,
            string civility, string? address,
            string? cellPhone, string? email,
            string? nationality, string? picture)
        {
            PK_Civil = Guid.NewGuid();
            Creation = DateTime.Now;
            LastUpdate = Creation;
            BirthDate = birthDate;
            DeathDate = deathDate;
            FirstName = firstName;
            LastName = lastName;
            Civility = civility;
            Address = address;
            CellPhone = cellPhone;
            Email = email;
            Nationality = nationality;
            Picture = picture;
            Nb_Incident_Declared = 0;
            Nb_Time_Being_Victim = 0;
            Orgas = new List<OrgaModel>();
        }
    }
}
