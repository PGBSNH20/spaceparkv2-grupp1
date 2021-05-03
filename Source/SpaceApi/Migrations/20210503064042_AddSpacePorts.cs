using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceApi.Migrations
{
    public partial class AddSpacePorts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpacePortId",
                table: "Parkings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SpacePorts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpacePorts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SpacePorts",
                columns: new[] { "Id", "PortName" },
                values: new object[] { 1, "Darth Port" });

            migrationBuilder.InsertData(
                table: "SpacePorts",
                columns: new[] { "Id", "PortName" },
                values: new object[] { 2, "Port 2" });

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpacePortId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpacePortId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpacePortId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 4,
                column: "SpacePortId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 5,
                column: "SpacePortId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_SpacePortId",
                table: "Parkings",
                column: "SpacePortId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_SpacePorts_SpacePortId",
                table: "Parkings",
                column: "SpacePortId",
                principalTable: "SpacePorts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_SpacePorts_SpacePortId",
                table: "Parkings");

            migrationBuilder.DropTable(
                name: "SpacePorts");

            migrationBuilder.DropIndex(
                name: "IX_Parkings_SpacePortId",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "SpacePortId",
                table: "Parkings");
        }
    }
}
