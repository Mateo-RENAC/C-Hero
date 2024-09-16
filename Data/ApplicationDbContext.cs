using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using C_Hero.Models.Entities;

namespace C_Hero.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CivilModel> Civils { get; set; }
        public DbSet<OrgaModel> Orgas { get; set; }
        public DbSet<SuperHeroModel> SuperHeroes { get; set; }
        public DbSet<SuperVillainModel> SuperVillains { get; set; }
        public DbSet<IncidentModel> Incidents { get; set; }
        public DbSet<MissionModel> Missions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration de la clé primaire pour CivilModel
            modelBuilder.Entity<CivilModel>()
                .HasKey(c => c.PK_Civil);

            // Configuration de la clé primaire pour IncidentModel
            modelBuilder.Entity<IncidentModel>()
                .HasKey(i => i.IncidentId);

            // Configuration de la clé primaire pour MissionModel
            modelBuilder.Entity<MissionModel>()
                .HasKey(m => m.PK_Mission);

            // Configuration de la clé primaire pour OrgaModel
            modelBuilder.Entity<OrgaModel>()
                .HasKey(o => o.PK_Orga);

            // Configuration de la clé primaire pour RapportModel
            modelBuilder.Entity<RapportModel>()
                .HasKey(r => r.FK_Rapport);

            //Configuration de la clé primaire pour SuperHeroModel
            modelBuilder.Entity<SuperHeroModel>()
                .HasKey(s => s.PK_SuperH);

            //Configuration de la clé primaire pour SuperVillainModel
            modelBuilder.Entity<SuperVillainModel>()
                .HasKey(s => s.PK_SuperV);

            //Configuration de la clée primaire pour CrisisModel
            modelBuilder.Entity<CrisisModel>()
                .HasKey(c => c.PK_Crisis);

            //Configuration de la clée primaire pour DisputeModel
            modelBuilder.Entity<DisputeModel>()
                .HasKey(d => d.PK_Dispute);

            // Configuration de la relation many-to-many pour Dirigeant
            modelBuilder.Entity<OrgaModel>()
                .HasMany(o => o.Dirigeant)
                .WithMany(c => c.DirigeantOrgas)
                .UsingEntity(j => j.ToTable("OrgaDirigeants"));

            // Configuration de la relation many-to-many pour Members
            modelBuilder.Entity<OrgaModel>()
                .HasMany(o => o.Members)
                .WithMany(c => c.Orgas)
                .UsingEntity(j => j.ToTable("OrgaMembers"));

            // Configuration de la relation many-to-many pour Heroes
            modelBuilder.Entity<OrgaModel>()
                .HasMany(o => o.Heroes)
                .WithMany(h => h.Orgas)
                .UsingEntity(j => j.ToTable("OrgaHeroes"));

            // Configuration de la relation many-to-many pour Villains
            modelBuilder.Entity<OrgaModel>()
                .HasMany(o => o.Villains)
                .WithMany(v => v.Orgas)
                .UsingEntity(j => j.ToTable("OrgaVillains"));

            // Configuration de la relation many-to-many pour Villains dans IncidentModel
            modelBuilder.Entity<IncidentModel>()
                .HasMany(i => i.Villains)
                .WithMany(v => v.Incidents)
                .UsingEntity(j => j.ToTable("IncidentVillains"));
        }
    }
}
