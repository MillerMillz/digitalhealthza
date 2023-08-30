using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class secondOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Strength",
                table: "MedActiveIngredients");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Medications",
                newName: "MedicationName");

            migrationBuilder.RenameColumn(
                name: "Symptoms",
                table: "ConditionDiagnoses",
                newName: "ICD10Code");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ConditionDiagnoses",
                newName: "DiagnosisName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ActiveIngredients",
                newName: "ActiveIngredientName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Prescriptions",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Prescriptions",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "Pharmacists",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "Patients",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Doctors",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Doctors",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ActiveIngrStrengths",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveIngrID = table.Column<int>(nullable: false),
                    StrengthID = table.Column<int>(nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveIngrStrengths", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LineActiveIngres",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineID = table.Column<int>(nullable: false),
                    AISID = table.Column<int>(nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineActiveIngres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Strengths",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheStrength = table.Column<string>(nullable: true),
                    Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strengths", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveIngrStrengths");

            migrationBuilder.DropTable(
                name: "LineActiveIngres");

            migrationBuilder.DropTable(
                name: "Strengths");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "MedicationName",
                table: "Medications",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ICD10Code",
                table: "ConditionDiagnoses",
                newName: "Symptoms");

            migrationBuilder.RenameColumn(
                name: "DiagnosisName",
                table: "ConditionDiagnoses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ActiveIngredientName",
                table: "ActiveIngredients",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "MedActiveIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
