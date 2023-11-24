using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealHub.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormList",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    userId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    age = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    weight = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    height = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    symptoms = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    duration = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    diseaseHistory = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrognosisList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    formId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrognosisList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userList",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Stars = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    Authorized = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PrognosisId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_PrognosisList_PrognosisId",
                        column: x => x.PrognosisId,
                        principalTable: "PrognosisList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PrognosisId",
                table: "Feedbacks",
                column: "PrognosisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FormList");

            migrationBuilder.DropTable(
                name: "userList");

            migrationBuilder.DropTable(
                name: "PrognosisList");
        }
    }
}
