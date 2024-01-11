using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDemo2.Migrations
{
    /// <inheritdoc />
    public partial class ttest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildModels_ParentModels_ParentModelId",
                table: "ChildModels");

            migrationBuilder.AlterColumn<int>(
                name: "ParentModelId",
                table: "ChildModels",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildModels_ParentModels_ParentModelId",
                table: "ChildModels",
                column: "ParentModelId",
                principalTable: "ParentModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildModels_ParentModels_ParentModelId",
                table: "ChildModels");

            migrationBuilder.AlterColumn<int>(
                name: "ParentModelId",
                table: "ChildModels",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildModels_ParentModels_ParentModelId",
                table: "ChildModels",
                column: "ParentModelId",
                principalTable: "ParentModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
