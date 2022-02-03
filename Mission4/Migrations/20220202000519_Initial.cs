using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission4.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_Responses_Categorys_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categorys",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Fantasy" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 5, "Horror" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 6, "Mystery" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 7, "Romance" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 8, "Thriller" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 9, "Other" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Doug Liman", false, "", "Awesome Movie!", "PG-13", "Jason Bourne: Bourne Identity", 2002 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 3, "Gavin O'Conner", false, "", "Watch alone, makes me emotional", "PG-13", "Warrior", 2011 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 4, "Denis Villeneuve", false, "", "Super Awesome Movie, should read the book too...", "PG-13", "Dune", 2021 });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryID",
                table: "Responses",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
