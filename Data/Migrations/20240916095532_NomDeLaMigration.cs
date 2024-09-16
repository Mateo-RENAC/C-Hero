using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C_Hero.Data.Migrations
{
    /// <inheritdoc />
    public partial class NomDeLaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Civils",
                columns: table => new
                {
                    PK_Civil = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Civility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nb_Incident_Declared = table.Column<int>(type: "int", nullable: false),
                    Nb_Time_Being_Victim = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Civils", x => x.PK_Civil);
                });

            migrationBuilder.CreateTable(
                name: "Orgas",
                columns: table => new
                {
                    PK_Orga = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Social_Siege = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nb_Incident_Declared = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgas", x => x.PK_Orga);
                });

            migrationBuilder.CreateTable(
                name: "SuperVillains",
                columns: table => new
                {
                    PK_SuperV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weakness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nb_Incident_Caused = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IdentityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperVillains", x => x.PK_SuperV);
                    table.ForeignKey(
                        name: "FK_SuperVillains_Civils_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "Civils",
                        principalColumn: "PK_Civil");
                });

            migrationBuilder.CreateTable(
                name: "DisputeModel",
                columns: table => new
                {
                    PK_Dispute = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<float>(type: "real", nullable: true),
                    Photos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CivilId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisputeModel", x => x.PK_Dispute);
                    table.ForeignKey(
                        name: "FK_DisputeModel_Civils_CivilId",
                        column: x => x.CivilId,
                        principalTable: "Civils",
                        principalColumn: "PK_Civil");
                    table.ForeignKey(
                        name: "FK_DisputeModel_Orgas_OrgaId",
                        column: x => x.OrgaId,
                        principalTable: "Orgas",
                        principalColumn: "PK_Orga");
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Localization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orga_DecleareId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Civil_DecleareId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_Civils_Civil_DecleareId",
                        column: x => x.Civil_DecleareId,
                        principalTable: "Civils",
                        principalColumn: "PK_Civil");
                    table.ForeignKey(
                        name: "FK_Incidents_Orgas_Orga_DecleareId",
                        column: x => x.Orga_DecleareId,
                        principalTable: "Orgas",
                        principalColumn: "PK_Orga");
                });

            migrationBuilder.CreateTable(
                name: "OrgaDirigeants",
                columns: table => new
                {
                    DirigeantOrgasPK_Orga = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirigeantPK_Civil = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgaDirigeants", x => new { x.DirigeantOrgasPK_Orga, x.DirigeantPK_Civil });
                    table.ForeignKey(
                        name: "FK_OrgaDirigeants_Civils_DirigeantPK_Civil",
                        column: x => x.DirigeantPK_Civil,
                        principalTable: "Civils",
                        principalColumn: "PK_Civil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgaDirigeants_Orgas_DirigeantOrgasPK_Orga",
                        column: x => x.DirigeantOrgasPK_Orga,
                        principalTable: "Orgas",
                        principalColumn: "PK_Orga",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgaMembers",
                columns: table => new
                {
                    MembersPK_Civil = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgasPK_Orga = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgaMembers", x => new { x.MembersPK_Civil, x.OrgasPK_Orga });
                    table.ForeignKey(
                        name: "FK_OrgaMembers_Civils_MembersPK_Civil",
                        column: x => x.MembersPK_Civil,
                        principalTable: "Civils",
                        principalColumn: "PK_Civil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgaMembers_Orgas_OrgasPK_Orga",
                        column: x => x.OrgasPK_Orga,
                        principalTable: "Orgas",
                        principalColumn: "PK_Orga",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgaVillains",
                columns: table => new
                {
                    OrgasPK_Orga = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VillainsPK_SuperV = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgaVillains", x => new { x.OrgasPK_Orga, x.VillainsPK_SuperV });
                    table.ForeignKey(
                        name: "FK_OrgaVillains_Orgas_OrgasPK_Orga",
                        column: x => x.OrgasPK_Orga,
                        principalTable: "Orgas",
                        principalColumn: "PK_Orga",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgaVillains_SuperVillains_VillainsPK_SuperV",
                        column: x => x.VillainsPK_SuperV,
                        principalTable: "SuperVillains",
                        principalColumn: "PK_SuperV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrisisModel",
                columns: table => new
                {
                    PK_Crisis = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FK_Dispute = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisputePK_Dispute = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrisisModel", x => x.PK_Crisis);
                    table.ForeignKey(
                        name: "FK_CrisisModel_DisputeModel_DisputePK_Dispute",
                        column: x => x.DisputePK_Dispute,
                        principalTable: "DisputeModel",
                        principalColumn: "PK_Dispute");
                });

            migrationBuilder.CreateTable(
                name: "IncidentVillains",
                columns: table => new
                {
                    IncidentsIncidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VillainsPK_SuperV = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentVillains", x => new { x.IncidentsIncidentId, x.VillainsPK_SuperV });
                    table.ForeignKey(
                        name: "FK_IncidentVillains_Incidents_IncidentsIncidentId",
                        column: x => x.IncidentsIncidentId,
                        principalTable: "Incidents",
                        principalColumn: "IncidentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncidentVillains_SuperVillains_VillainsPK_SuperV",
                        column: x => x.VillainsPK_SuperV,
                        principalTable: "SuperVillains",
                        principalColumn: "PK_SuperV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    PK_Mission = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoreInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Travel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emergency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_Incident = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IncidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.PK_Mission);
                    table.ForeignKey(
                        name: "FK_Missions_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "IncidentId");
                });

            migrationBuilder.CreateTable(
                name: "SuperHeroes",
                columns: table => new
                {
                    PK_SuperH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weakness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nb_Incident_Solved = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    SecretIdentityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MissionModelPK_Mission = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroes", x => x.PK_SuperH);
                    table.ForeignKey(
                        name: "FK_SuperHeroes_Civils_SecretIdentityId",
                        column: x => x.SecretIdentityId,
                        principalTable: "Civils",
                        principalColumn: "PK_Civil");
                    table.ForeignKey(
                        name: "FK_SuperHeroes_Missions_MissionModelPK_Mission",
                        column: x => x.MissionModelPK_Mission,
                        principalTable: "Missions",
                        principalColumn: "PK_Mission");
                });

            migrationBuilder.CreateTable(
                name: "OrgaHeroes",
                columns: table => new
                {
                    HeroesPK_SuperH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgasPK_Orga = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgaHeroes", x => new { x.HeroesPK_SuperH, x.OrgasPK_Orga });
                    table.ForeignKey(
                        name: "FK_OrgaHeroes_Orgas_OrgasPK_Orga",
                        column: x => x.OrgasPK_Orga,
                        principalTable: "Orgas",
                        principalColumn: "PK_Orga",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgaHeroes_SuperHeroes_HeroesPK_SuperH",
                        column: x => x.HeroesPK_SuperH,
                        principalTable: "SuperHeroes",
                        principalColumn: "PK_SuperH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RapportModel",
                columns: table => new
                {
                    FK_Rapport = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nb_Victim = table.Column<int>(type: "int", nullable: false),
                    FK_Civil = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CivilPK_Civil = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_Orga = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrgaPK_Orga = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_SuperH = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuperHeroPK_SuperH = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_Mission = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MissionPK_Mission = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapportModel", x => x.FK_Rapport);
                    table.ForeignKey(
                        name: "FK_RapportModel_Civils_CivilPK_Civil",
                        column: x => x.CivilPK_Civil,
                        principalTable: "Civils",
                        principalColumn: "PK_Civil");
                    table.ForeignKey(
                        name: "FK_RapportModel_Missions_MissionPK_Mission",
                        column: x => x.MissionPK_Mission,
                        principalTable: "Missions",
                        principalColumn: "PK_Mission");
                    table.ForeignKey(
                        name: "FK_RapportModel_Orgas_OrgaPK_Orga",
                        column: x => x.OrgaPK_Orga,
                        principalTable: "Orgas",
                        principalColumn: "PK_Orga");
                    table.ForeignKey(
                        name: "FK_RapportModel_SuperHeroes_SuperHeroPK_SuperH",
                        column: x => x.SuperHeroPK_SuperH,
                        principalTable: "SuperHeroes",
                        principalColumn: "PK_SuperH");
                });

            migrationBuilder.CreateTable(
                name: "CrisisModelRapportModel",
                columns: table => new
                {
                    CrisesPK_Crisis = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RapportsFK_Rapport = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrisisModelRapportModel", x => new { x.CrisesPK_Crisis, x.RapportsFK_Rapport });
                    table.ForeignKey(
                        name: "FK_CrisisModelRapportModel_CrisisModel_CrisesPK_Crisis",
                        column: x => x.CrisesPK_Crisis,
                        principalTable: "CrisisModel",
                        principalColumn: "PK_Crisis",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrisisModelRapportModel_RapportModel_RapportsFK_Rapport",
                        column: x => x.RapportsFK_Rapport,
                        principalTable: "RapportModel",
                        principalColumn: "FK_Rapport",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrisisModel_DisputePK_Dispute",
                table: "CrisisModel",
                column: "DisputePK_Dispute");

            migrationBuilder.CreateIndex(
                name: "IX_CrisisModelRapportModel_RapportsFK_Rapport",
                table: "CrisisModelRapportModel",
                column: "RapportsFK_Rapport");

            migrationBuilder.CreateIndex(
                name: "IX_DisputeModel_CivilId",
                table: "DisputeModel",
                column: "CivilId");

            migrationBuilder.CreateIndex(
                name: "IX_DisputeModel_OrgaId",
                table: "DisputeModel",
                column: "OrgaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_Civil_DecleareId",
                table: "Incidents",
                column: "Civil_DecleareId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_Orga_DecleareId",
                table: "Incidents",
                column: "Orga_DecleareId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentVillains_VillainsPK_SuperV",
                table: "IncidentVillains",
                column: "VillainsPK_SuperV");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_IncidentId",
                table: "Missions",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgaDirigeants_DirigeantPK_Civil",
                table: "OrgaDirigeants",
                column: "DirigeantPK_Civil");

            migrationBuilder.CreateIndex(
                name: "IX_OrgaHeroes_OrgasPK_Orga",
                table: "OrgaHeroes",
                column: "OrgasPK_Orga");

            migrationBuilder.CreateIndex(
                name: "IX_OrgaMembers_OrgasPK_Orga",
                table: "OrgaMembers",
                column: "OrgasPK_Orga");

            migrationBuilder.CreateIndex(
                name: "IX_OrgaVillains_VillainsPK_SuperV",
                table: "OrgaVillains",
                column: "VillainsPK_SuperV");

            migrationBuilder.CreateIndex(
                name: "IX_RapportModel_CivilPK_Civil",
                table: "RapportModel",
                column: "CivilPK_Civil");

            migrationBuilder.CreateIndex(
                name: "IX_RapportModel_MissionPK_Mission",
                table: "RapportModel",
                column: "MissionPK_Mission");

            migrationBuilder.CreateIndex(
                name: "IX_RapportModel_OrgaPK_Orga",
                table: "RapportModel",
                column: "OrgaPK_Orga");

            migrationBuilder.CreateIndex(
                name: "IX_RapportModel_SuperHeroPK_SuperH",
                table: "RapportModel",
                column: "SuperHeroPK_SuperH");

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_MissionModelPK_Mission",
                table: "SuperHeroes",
                column: "MissionModelPK_Mission");

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_SecretIdentityId",
                table: "SuperHeroes",
                column: "SecretIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperVillains_IdentityId",
                table: "SuperVillains",
                column: "IdentityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrisisModelRapportModel");

            migrationBuilder.DropTable(
                name: "IncidentVillains");

            migrationBuilder.DropTable(
                name: "OrgaDirigeants");

            migrationBuilder.DropTable(
                name: "OrgaHeroes");

            migrationBuilder.DropTable(
                name: "OrgaMembers");

            migrationBuilder.DropTable(
                name: "OrgaVillains");

            migrationBuilder.DropTable(
                name: "CrisisModel");

            migrationBuilder.DropTable(
                name: "RapportModel");

            migrationBuilder.DropTable(
                name: "SuperVillains");

            migrationBuilder.DropTable(
                name: "DisputeModel");

            migrationBuilder.DropTable(
                name: "SuperHeroes");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Civils");

            migrationBuilder.DropTable(
                name: "Orgas");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}
