namespace C_Hero.Models.Entities
{
    public class RapportModel
    {
        public Guid FK_Rapport { get; set; }
        public DateTime Creation { get; set; }
        public string Comment { get; set; }
        public int Nb_Victim { get; set; }

        // Propriétés pour les relations avec CivilModel, OrgaModel et SuperHeroModel
        public Guid? FK_Civil { get; set; }
        public CivilModel? Civil { get; set; }
        public Guid? FK_Orga { get; set; }
        public OrgaModel? Orga { get; set; }
        public Guid? FK_SuperH { get; set; }
        public SuperHeroModel? SuperHero { get; set; }

        // Propriété pour la relation avec MissionModel
        public Guid? FK_Mission { get; set; }
        public MissionModel? Mission { get; set; }

        // Collection pour la relation many-to-many avec CrisisModel
        public ICollection<CrisisModel> Crises { get; set; }

        public RapportModel()
        {
            FK_Rapport = Guid.NewGuid();
            Creation = DateTime.Now;
            Crises = new List<CrisisModel>();
        }

        public RapportModel(string comment, int nb_Victim, CivilModel? civil = null, OrgaModel? orga = null, SuperHeroModel? superHero = null, MissionModel? mission = null, ICollection<CrisisModel>? crises = null)
        {
            FK_Rapport = Guid.NewGuid();
            Creation = DateTime.Now;
            Comment = comment;
            Nb_Victim = nb_Victim;
            Civil = civil;
            FK_Civil = civil?.PK_Civil;
            Orga = orga;
            FK_Orga = orga?.PK_Orga;
            SuperHero = superHero;
            FK_SuperH = superHero?.PK_SuperH;
            Mission = mission;
            FK_Mission = mission?.PK_Mission;
            Crises = crises ?? new List<CrisisModel>();
        }
    }
}
