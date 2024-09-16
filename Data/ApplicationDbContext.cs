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
                .WithMany(h => h.Orga)
                .UsingEntity(j => j.ToTable("OrgaHeroes"));

            // Configuration de la relation many-to-many pour Villains
            modelBuilder.Entity<OrgaModel>()
                .HasMany(o => o.Villains)
                .WithMany(v => v.Orga)
                .UsingEntity(j => j.ToTable("OrgaVillains"));

            // Configuration de la relation many-to-many pour Villains dans IncidentModel
            modelBuilder.Entity<IncidentModel>()
                .HasMany(i => i.Villains)
                .WithMany(v => v.Incidents)
                .UsingEntity(j => j.ToTable("IncidentVillains"));
        }
    }
}
