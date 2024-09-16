namespace C_Hero.Models.Entities
{
    public class DisputeModel
    {
        public Guid PK_Dispute { get; set; }
        public DateTime Creation { get; set; }
        public string Type { get; set; }
        public string? Comment { get; set; }
        public float? Cost { get; set; }
        public string? Photos { get; set; }

        // Propriétés pour les relations avec OrgaModel et CivilModel
        public Guid? OrgaId { get; set; }
        public OrgaModel? Orga { get; set; }
        public Guid? CivilId { get; set; }
        public CivilModel? Civil { get; set; }

        public DisputeModel()
        {
            PK_Dispute = Guid.NewGuid();
            Creation = DateTime.Now;
        }

        public DisputeModel(string type, string? comment = null, float? cost = null, string? photos = null, OrgaModel? orga = null, CivilModel? civil = null)
        {
            PK_Dispute = Guid.NewGuid();
            Creation = DateTime.Now;
            Type = type;
            Comment = comment;
            Cost = cost;
            Photos = photos;
            Orga = orga;
            OrgaId = orga?.PK_Orga;
            Civil = civil;
            CivilId = civil?.PK_Civil;
        }
    }
}
