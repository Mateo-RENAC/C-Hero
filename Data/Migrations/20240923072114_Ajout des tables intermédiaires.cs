using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C_Hero.Data.Migrations
{
    /// <inheritdoc />
    public partial class Ajoutdestablesintermédiaires : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrisisModel_DisputeModel_DisputePK_Dispute",
                table: "CrisisModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CrisisModelRapportModel_CrisisModel_CrisesPK_Crisis",
                table: "CrisisModelRapportModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CrisisModelRapportModel_RapportModel_RapportsFK_Rapport",
                table: "CrisisModelRapportModel");

            migrationBuilder.DropForeignKey(
                name: "FK_DisputeModel_Civils_CivilId",
                table: "DisputeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_DisputeModel_Orgas_OrgaId",
                table: "DisputeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RapportModel_Civils_CivilPK_Civil",
                table: "RapportModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RapportModel_Missions_MissionPK_Mission",
                table: "RapportModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RapportModel_Orgas_OrgaPK_Orga",
                table: "RapportModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RapportModel_SuperHeroes_SuperHeroPK_SuperH",
                table: "RapportModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RapportModel",
                table: "RapportModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DisputeModel",
                table: "DisputeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrisisModel",
                table: "CrisisModel");

            migrationBuilder.RenameTable(
                name: "RapportModel",
                newName: "Rapports");

            migrationBuilder.RenameTable(
                name: "DisputeModel",
                newName: "Disputes");

            migrationBuilder.RenameTable(
                name: "CrisisModel",
                newName: "Crisises");

            migrationBuilder.RenameIndex(
                name: "IX_RapportModel_SuperHeroPK_SuperH",
                table: "Rapports",
                newName: "IX_Rapports_SuperHeroPK_SuperH");

            migrationBuilder.RenameIndex(
                name: "IX_RapportModel_OrgaPK_Orga",
                table: "Rapports",
                newName: "IX_Rapports_OrgaPK_Orga");

            migrationBuilder.RenameIndex(
                name: "IX_RapportModel_MissionPK_Mission",
                table: "Rapports",
                newName: "IX_Rapports_MissionPK_Mission");

            migrationBuilder.RenameIndex(
                name: "IX_RapportModel_CivilPK_Civil",
                table: "Rapports",
                newName: "IX_Rapports_CivilPK_Civil");

            migrationBuilder.RenameIndex(
                name: "IX_DisputeModel_OrgaId",
                table: "Disputes",
                newName: "IX_Disputes_OrgaId");

            migrationBuilder.RenameIndex(
                name: "IX_DisputeModel_CivilId",
                table: "Disputes",
                newName: "IX_Disputes_CivilId");

            migrationBuilder.RenameIndex(
                name: "IX_CrisisModel_DisputePK_Dispute",
                table: "Crisises",
                newName: "IX_Crisises_DisputePK_Dispute");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rapports",
                table: "Rapports",
                column: "FK_Rapport");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disputes",
                table: "Disputes",
                column: "PK_Dispute");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crisises",
                table: "Crisises",
                column: "PK_Crisis");

            migrationBuilder.AddForeignKey(
                name: "FK_Crisises_Disputes_DisputePK_Dispute",
                table: "Crisises",
                column: "DisputePK_Dispute",
                principalTable: "Disputes",
                principalColumn: "PK_Dispute");

            migrationBuilder.AddForeignKey(
                name: "FK_CrisisModelRapportModel_Crisises_CrisesPK_Crisis",
                table: "CrisisModelRapportModel",
                column: "CrisesPK_Crisis",
                principalTable: "Crisises",
                principalColumn: "PK_Crisis",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CrisisModelRapportModel_Rapports_RapportsFK_Rapport",
                table: "CrisisModelRapportModel",
                column: "RapportsFK_Rapport",
                principalTable: "Rapports",
                principalColumn: "FK_Rapport",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disputes_Civils_CivilId",
                table: "Disputes",
                column: "CivilId",
                principalTable: "Civils",
                principalColumn: "PK_Civil");

            migrationBuilder.AddForeignKey(
                name: "FK_Disputes_Orgas_OrgaId",
                table: "Disputes",
                column: "OrgaId",
                principalTable: "Orgas",
                principalColumn: "PK_Orga");

            migrationBuilder.AddForeignKey(
                name: "FK_Rapports_Civils_CivilPK_Civil",
                table: "Rapports",
                column: "CivilPK_Civil",
                principalTable: "Civils",
                principalColumn: "PK_Civil");

            migrationBuilder.AddForeignKey(
                name: "FK_Rapports_Missions_MissionPK_Mission",
                table: "Rapports",
                column: "MissionPK_Mission",
                principalTable: "Missions",
                principalColumn: "PK_Mission");

            migrationBuilder.AddForeignKey(
                name: "FK_Rapports_Orgas_OrgaPK_Orga",
                table: "Rapports",
                column: "OrgaPK_Orga",
                principalTable: "Orgas",
                principalColumn: "PK_Orga");

            migrationBuilder.AddForeignKey(
                name: "FK_Rapports_SuperHeroes_SuperHeroPK_SuperH",
                table: "Rapports",
                column: "SuperHeroPK_SuperH",
                principalTable: "SuperHeroes",
                principalColumn: "PK_SuperH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crisises_Disputes_DisputePK_Dispute",
                table: "Crisises");

            migrationBuilder.DropForeignKey(
                name: "FK_CrisisModelRapportModel_Crisises_CrisesPK_Crisis",
                table: "CrisisModelRapportModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CrisisModelRapportModel_Rapports_RapportsFK_Rapport",
                table: "CrisisModelRapportModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Disputes_Civils_CivilId",
                table: "Disputes");

            migrationBuilder.DropForeignKey(
                name: "FK_Disputes_Orgas_OrgaId",
                table: "Disputes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rapports_Civils_CivilPK_Civil",
                table: "Rapports");

            migrationBuilder.DropForeignKey(
                name: "FK_Rapports_Missions_MissionPK_Mission",
                table: "Rapports");

            migrationBuilder.DropForeignKey(
                name: "FK_Rapports_Orgas_OrgaPK_Orga",
                table: "Rapports");

            migrationBuilder.DropForeignKey(
                name: "FK_Rapports_SuperHeroes_SuperHeroPK_SuperH",
                table: "Rapports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rapports",
                table: "Rapports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disputes",
                table: "Disputes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crisises",
                table: "Crisises");

            migrationBuilder.RenameTable(
                name: "Rapports",
                newName: "RapportModel");

            migrationBuilder.RenameTable(
                name: "Disputes",
                newName: "DisputeModel");

            migrationBuilder.RenameTable(
                name: "Crisises",
                newName: "CrisisModel");

            migrationBuilder.RenameIndex(
                name: "IX_Rapports_SuperHeroPK_SuperH",
                table: "RapportModel",
                newName: "IX_RapportModel_SuperHeroPK_SuperH");

            migrationBuilder.RenameIndex(
                name: "IX_Rapports_OrgaPK_Orga",
                table: "RapportModel",
                newName: "IX_RapportModel_OrgaPK_Orga");

            migrationBuilder.RenameIndex(
                name: "IX_Rapports_MissionPK_Mission",
                table: "RapportModel",
                newName: "IX_RapportModel_MissionPK_Mission");

            migrationBuilder.RenameIndex(
                name: "IX_Rapports_CivilPK_Civil",
                table: "RapportModel",
                newName: "IX_RapportModel_CivilPK_Civil");

            migrationBuilder.RenameIndex(
                name: "IX_Disputes_OrgaId",
                table: "DisputeModel",
                newName: "IX_DisputeModel_OrgaId");

            migrationBuilder.RenameIndex(
                name: "IX_Disputes_CivilId",
                table: "DisputeModel",
                newName: "IX_DisputeModel_CivilId");

            migrationBuilder.RenameIndex(
                name: "IX_Crisises_DisputePK_Dispute",
                table: "CrisisModel",
                newName: "IX_CrisisModel_DisputePK_Dispute");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RapportModel",
                table: "RapportModel",
                column: "FK_Rapport");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisputeModel",
                table: "DisputeModel",
                column: "PK_Dispute");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrisisModel",
                table: "CrisisModel",
                column: "PK_Crisis");

            migrationBuilder.AddForeignKey(
                name: "FK_CrisisModel_DisputeModel_DisputePK_Dispute",
                table: "CrisisModel",
                column: "DisputePK_Dispute",
                principalTable: "DisputeModel",
                principalColumn: "PK_Dispute");

            migrationBuilder.AddForeignKey(
                name: "FK_CrisisModelRapportModel_CrisisModel_CrisesPK_Crisis",
                table: "CrisisModelRapportModel",
                column: "CrisesPK_Crisis",
                principalTable: "CrisisModel",
                principalColumn: "PK_Crisis",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CrisisModelRapportModel_RapportModel_RapportsFK_Rapport",
                table: "CrisisModelRapportModel",
                column: "RapportsFK_Rapport",
                principalTable: "RapportModel",
                principalColumn: "FK_Rapport",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisputeModel_Civils_CivilId",
                table: "DisputeModel",
                column: "CivilId",
                principalTable: "Civils",
                principalColumn: "PK_Civil");

            migrationBuilder.AddForeignKey(
                name: "FK_DisputeModel_Orgas_OrgaId",
                table: "DisputeModel",
                column: "OrgaId",
                principalTable: "Orgas",
                principalColumn: "PK_Orga");

            migrationBuilder.AddForeignKey(
                name: "FK_RapportModel_Civils_CivilPK_Civil",
                table: "RapportModel",
                column: "CivilPK_Civil",
                principalTable: "Civils",
                principalColumn: "PK_Civil");

            migrationBuilder.AddForeignKey(
                name: "FK_RapportModel_Missions_MissionPK_Mission",
                table: "RapportModel",
                column: "MissionPK_Mission",
                principalTable: "Missions",
                principalColumn: "PK_Mission");

            migrationBuilder.AddForeignKey(
                name: "FK_RapportModel_Orgas_OrgaPK_Orga",
                table: "RapportModel",
                column: "OrgaPK_Orga",
                principalTable: "Orgas",
                principalColumn: "PK_Orga");

            migrationBuilder.AddForeignKey(
                name: "FK_RapportModel_SuperHeroes_SuperHeroPK_SuperH",
                table: "RapportModel",
                column: "SuperHeroPK_SuperH",
                principalTable: "SuperHeroes",
                principalColumn: "PK_SuperH");
        }
    }
}
