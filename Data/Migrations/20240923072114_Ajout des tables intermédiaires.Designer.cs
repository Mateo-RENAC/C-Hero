﻿// <auto-generated />
using System;
using C_Hero.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace C_Hero.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240923072114_Ajout des tables intermédiaires")]
    partial class Ajoutdestablesintermédiaires
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("C_Hero.Models.Entities.CivilModel", b =>
                {
                    b.Property<Guid>("PK_Civil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CellPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Civility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nb_Incident_Declared")
                        .HasColumnType("int");

                    b.Property<int>("Nb_Time_Being_Victim")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PK_Civil");

                    b.ToTable("Civils");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.CrisisModel", b =>
                {
                    b.Property<Guid>("PK_Crisis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DisputePK_Dispute")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FK_Dispute")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PK_Crisis");

                    b.HasIndex("DisputePK_Dispute");

                    b.ToTable("Crisises");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.DisputeModel", b =>
                {
                    b.Property<Guid>("PK_Dispute")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CivilId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("OrgaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Photos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PK_Dispute");

                    b.HasIndex("CivilId");

                    b.HasIndex("OrgaId");

                    b.ToTable("Disputes");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.IncidentModel", b =>
                {
                    b.Property<Guid>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Civil_DecleareId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Orga_DecleareId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IncidentId");

                    b.HasIndex("Civil_DecleareId");

                    b.HasIndex("Orga_DecleareId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.MissionModel", b =>
                {
                    b.Property<Guid>("PK_Mission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Emergency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FK_Incident")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IncidentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoreInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Severity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Travel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PK_Mission");

                    b.HasIndex("IncidentId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.OrgaModel", b =>
                {
                    b.Property<Guid>("PK_Orga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nb_Incident_Declared")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Social_Siege")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PK_Orga");

                    b.ToTable("Orgas");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.RapportModel", b =>
                {
                    b.Property<Guid>("FK_Rapport")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CivilPK_Civil")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FK_Civil")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FK_Mission")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FK_Orga")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FK_SuperH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MissionPK_Mission")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Nb_Victim")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrgaPK_Orga")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SuperHeroPK_SuperH")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FK_Rapport");

                    b.HasIndex("CivilPK_Civil");

                    b.HasIndex("MissionPK_Mission");

                    b.HasIndex("OrgaPK_Orga");

                    b.HasIndex("SuperHeroPK_SuperH");

                    b.ToTable("Rapports");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.SuperHeroModel", b =>
                {
                    b.Property<Guid>("PK_SuperH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MissionModelPK_Mission")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nb_Incident_Solved")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Power")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<Guid?>("SecretIdentityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Weakness")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PK_SuperH");

                    b.HasIndex("MissionModelPK_Mission");

                    b.HasIndex("SecretIdentityId");

                    b.ToTable("SuperHeroes");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.SuperVillainModel", b =>
                {
                    b.Property<Guid>("PK_SuperV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdentityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nb_Incident_Caused")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Power")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Weakness")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PK_SuperV");

                    b.HasIndex("IdentityId");

                    b.ToTable("SuperVillains");
                });

            modelBuilder.Entity("CivilModelOrgaModel", b =>
                {
                    b.Property<Guid>("DirigeantOrgasPK_Orga")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DirigeantPK_Civil")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DirigeantOrgasPK_Orga", "DirigeantPK_Civil");

                    b.HasIndex("DirigeantPK_Civil");

                    b.ToTable("OrgaDirigeants", (string)null);
                });

            modelBuilder.Entity("CivilModelOrgaModel1", b =>
                {
                    b.Property<Guid>("MembersPK_Civil")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrgasPK_Orga")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MembersPK_Civil", "OrgasPK_Orga");

                    b.HasIndex("OrgasPK_Orga");

                    b.ToTable("OrgaMembers", (string)null);
                });

            modelBuilder.Entity("CrisisModelRapportModel", b =>
                {
                    b.Property<Guid>("CrisesPK_Crisis")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RapportsFK_Rapport")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CrisesPK_Crisis", "RapportsFK_Rapport");

                    b.HasIndex("RapportsFK_Rapport");

                    b.ToTable("CrisisModelRapportModel");
                });

            modelBuilder.Entity("IncidentModelSuperVillainModel", b =>
                {
                    b.Property<Guid>("IncidentsIncidentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VillainsPK_SuperV")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IncidentsIncidentId", "VillainsPK_SuperV");

                    b.HasIndex("VillainsPK_SuperV");

                    b.ToTable("IncidentVillains", (string)null);
                });

            modelBuilder.Entity("OrgaModelSuperHeroModel", b =>
                {
                    b.Property<Guid>("HeroesPK_SuperH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrgasPK_Orga")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HeroesPK_SuperH", "OrgasPK_Orga");

                    b.HasIndex("OrgasPK_Orga");

                    b.ToTable("OrgaHeroes", (string)null);
                });

            modelBuilder.Entity("OrgaModelSuperVillainModel", b =>
                {
                    b.Property<Guid>("OrgasPK_Orga")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VillainsPK_SuperV")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrgasPK_Orga", "VillainsPK_SuperV");

                    b.HasIndex("VillainsPK_SuperV");

                    b.ToTable("OrgaVillains", (string)null);
                });

            modelBuilder.Entity("C_Hero.Models.Entities.CrisisModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.DisputeModel", "Dispute")
                        .WithMany()
                        .HasForeignKey("DisputePK_Dispute");

                    b.Navigation("Dispute");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.DisputeModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.CivilModel", "Civil")
                        .WithMany()
                        .HasForeignKey("CivilId");

                    b.HasOne("C_Hero.Models.Entities.OrgaModel", "Orga")
                        .WithMany()
                        .HasForeignKey("OrgaId");

                    b.Navigation("Civil");

                    b.Navigation("Orga");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.IncidentModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.CivilModel", "Civil_Decleare")
                        .WithMany()
                        .HasForeignKey("Civil_DecleareId");

                    b.HasOne("C_Hero.Models.Entities.OrgaModel", "Orga_Decleare")
                        .WithMany()
                        .HasForeignKey("Orga_DecleareId");

                    b.Navigation("Civil_Decleare");

                    b.Navigation("Orga_Decleare");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.MissionModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.IncidentModel", "Incident")
                        .WithMany()
                        .HasForeignKey("IncidentId");

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.RapportModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.CivilModel", "Civil")
                        .WithMany()
                        .HasForeignKey("CivilPK_Civil");

                    b.HasOne("C_Hero.Models.Entities.MissionModel", "Mission")
                        .WithMany()
                        .HasForeignKey("MissionPK_Mission");

                    b.HasOne("C_Hero.Models.Entities.OrgaModel", "Orga")
                        .WithMany()
                        .HasForeignKey("OrgaPK_Orga");

                    b.HasOne("C_Hero.Models.Entities.SuperHeroModel", "SuperHero")
                        .WithMany()
                        .HasForeignKey("SuperHeroPK_SuperH");

                    b.Navigation("Civil");

                    b.Navigation("Mission");

                    b.Navigation("Orga");

                    b.Navigation("SuperHero");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.SuperHeroModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.MissionModel", null)
                        .WithMany("Heroes")
                        .HasForeignKey("MissionModelPK_Mission");

                    b.HasOne("C_Hero.Models.Entities.CivilModel", "SecretIdentity")
                        .WithMany()
                        .HasForeignKey("SecretIdentityId");

                    b.Navigation("SecretIdentity");
                });

            modelBuilder.Entity("C_Hero.Models.Entities.SuperVillainModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.CivilModel", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("CivilModelOrgaModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.OrgaModel", null)
                        .WithMany()
                        .HasForeignKey("DirigeantOrgasPK_Orga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("C_Hero.Models.Entities.CivilModel", null)
                        .WithMany()
                        .HasForeignKey("DirigeantPK_Civil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CivilModelOrgaModel1", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.CivilModel", null)
                        .WithMany()
                        .HasForeignKey("MembersPK_Civil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("C_Hero.Models.Entities.OrgaModel", null)
                        .WithMany()
                        .HasForeignKey("OrgasPK_Orga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CrisisModelRapportModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.CrisisModel", null)
                        .WithMany()
                        .HasForeignKey("CrisesPK_Crisis")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("C_Hero.Models.Entities.RapportModel", null)
                        .WithMany()
                        .HasForeignKey("RapportsFK_Rapport")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IncidentModelSuperVillainModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.IncidentModel", null)
                        .WithMany()
                        .HasForeignKey("IncidentsIncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("C_Hero.Models.Entities.SuperVillainModel", null)
                        .WithMany()
                        .HasForeignKey("VillainsPK_SuperV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrgaModelSuperHeroModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.SuperHeroModel", null)
                        .WithMany()
                        .HasForeignKey("HeroesPK_SuperH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("C_Hero.Models.Entities.OrgaModel", null)
                        .WithMany()
                        .HasForeignKey("OrgasPK_Orga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrgaModelSuperVillainModel", b =>
                {
                    b.HasOne("C_Hero.Models.Entities.OrgaModel", null)
                        .WithMany()
                        .HasForeignKey("OrgasPK_Orga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("C_Hero.Models.Entities.SuperVillainModel", null)
                        .WithMany()
                        .HasForeignKey("VillainsPK_SuperV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("C_Hero.Models.Entities.MissionModel", b =>
                {
                    b.Navigation("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}
