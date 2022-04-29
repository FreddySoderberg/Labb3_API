using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb3_WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestTitle = table.Column<string>(nullable: true),
                    InterestDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "InterestLinks",
                columns: table => new
                {
                    InterestLinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestId = table.Column<int>(nullable: false),
                    LinkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLinks", x => x.InterestLinkId);
                    table.ForeignKey(
                        name: "FK_InterestLinks_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestLinks_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonInterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    InterestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.PersonInterestId);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "InterestDescription", "InterestTitle" },
                values: new object[,]
                {
                    { 1, "Reading, talking, watching and playing games", "Gaming" },
                    { 2, "Loves cooking food", "Cooking" },
                    { 3, "Looking and talking about art", "Art" },
                    { 4, "Watching and commenting on Youtube videos", "Youtube" },
                    { 5, "Reading, talking and writing about programming", "Programming" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "LinkUrl" },
                values: new object[,]
                {
                    { 1, "https://www.pcgamer.com/" },
                    { 2, "https://www.cookingclassy.com/" },
                    { 3, "https://www.reddit.com/r/Art/" },
                    { 4, "https://www.artstation.com/?sort_by=community" },
                    { 5, "https://www.youtube.com/watch?v=dQw4w9WgXcQ" },
                    { 6, "https://stackoverflow.com/" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "PersonName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Maria", "2489576" },
                    { 2, "Erik", "3498672" },
                    { 3, "Anna", "4903567934" },
                    { 4, "Lars", "52579398467" },
                    { 5, "Margareta", "6934856734" }
                });

            migrationBuilder.InsertData(
                table: "InterestLinks",
                columns: new[] { "InterestLinkId", "InterestId", "LinkId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 3, 4 },
                    { 5, 4, 5 },
                    { 6, 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "PersonInterestId", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 2 },
                    { 4, 3, 3 },
                    { 5, 4, 4 },
                    { 6, 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_InterestId",
                table: "InterestLinks",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_LinkId",
                table: "InterestLinks",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonId",
                table: "PersonInterests",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLinks");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
