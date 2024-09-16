namespace C_Hero.Models.Entities
{
    public class CrisisModel
    {
        public Guid PK_Crisis { get; set; }
        public DateTime Creation { get; set; }
        public string Type { get; set; }
        public string? Comment { get; set; }

        // Propriété pour la relation avec DisputeModel
        public Guid? FK_Dispute { get; set; }
        public DisputeModel? Dispute { get; set; }

        // Collection pour la relation many-to-many avec RapportModel
        public ICollection<RapportModel> Rapports { get; set; }

        public CrisisModel()
        {
            PK_Crisis = Guid.NewGuid();
            Creation = DateTime.Now;
            Rapports = new List<RapportModel>();
        }

        public CrisisModel(string type, string? comment = null, DisputeModel? dispute = null, ICollection<RapportModel>? rapports = null)
        {
            PK_Crisis = Guid.NewGuid();
            Creation = DateTime.Now;
            Type = type;
            Comment = comment;
            Dispute = dispute;
            FK_Dispute = dispute?.PK_Dispute;
            Rapports = rapports ?? new List<RapportModel>();
        }
    }
}
