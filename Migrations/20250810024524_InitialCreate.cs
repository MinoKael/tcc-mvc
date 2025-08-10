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
                name: "ItensMidia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AutorDiretor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AnoLancamento = table.Column<int>(type: "integer", nullable: false),
                    Genero = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Sinopse = table.Column<string>(type: "text", nullable: true),
                    TipoMidia = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensMidia", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ItensMidia",
                columns: new[] { "Id", "AnoLancamento", "AutorDiretor", "Genero", "Sinopse", "TipoMidia", "Titulo" },
                values: new object[,]
                {
                    { 1, 1954, "J.R.R. Tolkien", "Fantasia", "Um jovem hobbit herda um anel mágico e perigoso que deve ser destruído antes que caia nas mãos do mal.", "Livro", "O Senhor dos Anéis: A Sociedade do Anel" },
                    { 2, 1965, "Frank Herbert", "Ficção Científica", "A jornada de um jovem nobre em um planeta desértico perigoso para garantir o futuro de seu povo.", "Livro", "Duna" },
                    { 3, 1972, "Francis Ford Coppola", "Crime, Drama", "O patriarca de uma dinastia do crime organizado transfere o controle de seu império clandestino para seu filho relutante.", "Filme", "O Poderoso Chefão" },
                    { 4, 2014, "Christopher Nolan", "Ficção Científica, Aventura", "Uma equipe de exploradores viaja através de um buraco de minhoca no espaço na tentativa de garantir a sobrevivência da humanidade.", "Filme", "Interestelar" },
                    { 5, 2008, "Vince Gilligan", "Crime, Drama, Suspense", "Um professor de química do ensino médio diagnosticado com câncer de pulmão inoperável passa a produzir e vender metanfetamina para garantir o futuro de sua família.", "Serie", "Breaking Bad" },
                    { 6, 2005, "Greg Daniels", "Comédia", "Um documentário sobre o dia a dia cômico e, por vezes, tocante dos funcionários de uma empresa de papel.", "Serie", "The Office (US)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensMidia");
        }
    }
}
