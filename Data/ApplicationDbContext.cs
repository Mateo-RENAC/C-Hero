using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using C_Hero.Models.Entities;

namespace C_Hero.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CivilModel> Civils { get; set; }
        public DbSet<OrgaModel> Orgas { get; set; }

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
        }
    }
}
