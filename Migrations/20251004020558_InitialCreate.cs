using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeuTccMvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ReleaseYear = table.Column<int>(type: "integer", nullable: true),
                    MediaType = table.Column<int>(type: "integer", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: true),
                    Sinopse = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Author = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ISBN = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Publisher = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Director = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: true),
                    Series_Director = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Seasons = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MediaItems",
                columns: new[] { "Id", "Author", "Discriminator", "Genre", "ISBN", "MediaType", "Publisher", "ReleaseYear", "Sinopse", "Title" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", "Book", "Fantasia", null, 1, null, 1954, "Um jovem hobbit herda um anel mágico e perigoso...", "O Senhor dos Anéis: A Sociedade do Anel" },
                    { 2, "Frank Herbert", "Book", "Ficção Científica", null, 1, null, 1965, "A jornada de um jovem nobre em um planeta desértico...", "Duna" }
                });

            migrationBuilder.InsertData(
                table: "MediaItems",
                columns: new[] { "Id", "Director", "Discriminator", "DurationMinutes", "Genre", "MediaType", "ReleaseYear", "Sinopse", "Title" },
                values: new object[,]
                {
                    { 3, "Francis Ford Coppola", "Movie", null, "Crime, Drama", 2, 1972, "O patriarca de uma dinastia do crime organizado...", "O Poderoso Chefão" },
                    { 4, "Christopher Nolan", "Movie", null, "Ficção Científica, Aventura", 2, 2014, "Uma equipe de exploradores viaja através de um buraco...", "Interestelar" }
                });

            migrationBuilder.InsertData(
                table: "MediaItems",
                columns: new[] { "Id", "Series_Director", "Discriminator", "Genre", "MediaType", "ReleaseYear", "Seasons", "Sinopse", "Title" },
                values: new object[,]
                {
                    { 5, "Vince Gilligan", "Series", "Crime, Drama, Suspense", 3, 2008, null, "Um professor de química diagnosticado com câncer...", "Breaking Bad" },
                    { 6, "Greg Daniels", "Series", "Comédia", 3, 2005, null, "Um documentário sobre o dia a dia cômico...", "The Office (US)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaItems");
        }
    }
}
