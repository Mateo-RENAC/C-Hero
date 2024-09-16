namespace C_Hero.Models.Entities
{
    public class IncidentModel
    {
        public Guid IncidentId { get; set; }
        public DateTime Creation { get; set; }
        public string Localization { get; set; }
        public string Description { get; set; }
        public string? Comment { get; set; }

        // Propriétés pour les relations nullable
        public Guid? Orga_DecleareId { get; set; }
        public OrgaModel? Orga_Decleare { get; set; }

        public Guid? Civil_DecleareId { get; set; }
        public CivilModel? Civil_Decleare { get; set; }

        // Collection nullable de vilains
        public ICollection<SuperVillainModel>? Villains { get; set; }

        // Constructeur par défaut
        public IncidentModel()
        {
            IncidentId = Guid.NewGuid();
            Creation = DateTime.Now;
            Localization = string.Empty; // Valeur par défaut pour éviter les erreurs de nullabilité
            Description = string.Empty;  // Valeur par défaut pour éviter les erreurs de nullabilité
            Villains = new List<SuperVillainModel>();
        }

        // Constructeur paramétré
        public IncidentModel(string localization, string description, string? comment = null, OrgaModel? orgaDecleare = null, CivilModel? civilDecleare = null, ICollection<SuperVillainModel>? villains = null)
        {
            IncidentId = Guid.NewGuid();
            Creation = DateTime.Now;
            Localization = localization;
            Description = description;
            Comment = comment;
            Orga_Decleare = orgaDecleare;
            Orga_DecleareId = orgaDecleare?.PK_Orga;
            Civil_Decleare = civilDecleare;
            Civil_DecleareId = civilDecleare?.PK_Civil;
            Villains = villains ?? new List<SuperVillainModel>();
        }
    }
}
