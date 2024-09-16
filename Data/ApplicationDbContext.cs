using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using C_Hero.Models.Entities;

namespace C_Hero.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CivilModel> Civils { get; set; }
        public DbSet<OrgaModel> Orgas { get; set; }
        public DbSet<SuperHeroModel> SuperHeroes { get; set; }
        public DbSet<SuperVillainModel> SuperVillains { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la relation many-to-many pour Members
            modelBuilder.Entity<CivilModel>()
                .HasMany(c => c.Orgas)
                .WithMany(o => o.Members)
                .UsingEntity(j => j.ToTable("CivilOrgaMembers"));

            // Configuration de la relation many-to-many pour Dirigeant
            modelBuilder.Entity<CivilModel>()
                .HasMany(c => c.Orgas)
                .WithMany(o => o.Dirigeant)
                .UsingEntity(j => j.ToTable("CivilOrgaDirigeant"));

            // Configuration pour SuperHeroModel
            modelBuilder.Entity<SuperHeroModel>()
                .HasOne(sh => sh.SecretIdentity)
                .WithMany()
                .HasForeignKey(sh => sh.SecretIdentityId)
                .IsRequired(false);

            // Configuration pour SuperVillainModel
            modelBuilder.Entity<SuperVillainModel>()
                .HasOne(sv => sv.Identity)
                .WithMany()
                .HasForeignKey(sv => sv.IdentityId)
                .IsRequired(false);

            // Configuration de la relation many-to-many pour Heroes
            modelBuilder.Entity<OrgaModel>()
                .HasMany(o => o.Heroes)
                .WithMany()
                .UsingEntity(j => j.ToTable("OrgaHeroes"));

            // Configuration de la relation many-to-many pour Villains
            modelBuilder.Entity<OrgaModel>()
                .HasMany(o => o.Villains)
                .WithMany()
                .UsingEntity(j => j.ToTable("OrgaVillains"));
        }
    }
}
