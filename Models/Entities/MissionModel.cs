namespace C_Hero.Models.Entities
{
    public class MissionModel
    {
        public Guid PK_Mission { get; set; }
        public DateTime Creation { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string? MoreInfo { get; set; }
        public string? Travel { get; set; }
        public string Severity { get; set; }
        public string Emergency { get; set; }

        // Propriété pour la clé étrangère
        public Guid? FK_Incident { get; set; }
        public IncidentModel? Incident { get; set; }

        // Collection de héros participants
        public ICollection<SuperHeroModel> Heroes { get; set; }

        public MissionModel()
        {
            PK_Mission = Guid.NewGuid();
            Creation = DateTime.Now;
            Heroes = new List<SuperHeroModel>();
        }

        public MissionModel(Guid pK_Mission, DateTime creation, string type, string title, string? moreInfo, string? travel, string severity, string emergency, IncidentModel? incident = null, ICollection<SuperHeroModel>? heroes = null)
        {
            PK_Mission = pK_Mission;
            Creation = creation;
            Type = type;
            Title = title;
            MoreInfo = moreInfo;
            Travel = travel;
            Severity = severity;
            Emergency = emergency;
            Incident = incident;
            FK_Incident = incident?.IncidentId;
            Heroes = heroes ?? new List<SuperHeroModel>();
        }
    }
}
