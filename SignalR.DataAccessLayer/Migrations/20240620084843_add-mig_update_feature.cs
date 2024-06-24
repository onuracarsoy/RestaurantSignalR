using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class addmig_update_feature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeatureDescription1",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureDescription2",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureDescription3",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "FeatureTitle3",
                table: "Features",
                newName: "FeatureTitle");

            migrationBuilder.RenameColumn(
                name: "FeatureTitle2",
                table: "Features",
                newName: "FeatureStatus");

            migrationBuilder.RenameColumn(
                name: "FeatureTitle1",
                table: "Features",
                newName: "FeatureDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeatureTitle",
                table: "Features",
                newName: "FeatureTitle3");

            migrationBuilder.RenameColumn(
                name: "FeatureStatus",
                table: "Features",
                newName: "FeatureTitle2");

            migrationBuilder.RenameColumn(
                name: "FeatureDescription",
                table: "Features",
                newName: "FeatureTitle1");

            migrationBuilder.AddColumn<string>(
                name: "FeatureDescription1",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeatureDescription2",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeatureDescription3",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
