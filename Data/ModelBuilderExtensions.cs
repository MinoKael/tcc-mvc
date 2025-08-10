using MeuTccMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuTccMvc.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ItemMidia>().HasData(
                new ItemMidia
                {
                    Id = 1,
                    Titulo = "O Senhor dos Anéis: A Sociedade do Anel",
                    AutorDiretor = "J.R.R. Tolkien",
                    AnoLancamento = 1954,
                    Genero = "Fantasia",
                    Sinopse = "Um jovem hobbit herda um anel mágico e perigoso que deve ser destruído antes que caia nas mãos do mal.",
                    TipoMidia = TipoMidia.Livro
                },
                new ItemMidia
                {
                    Id = 2,
                    Titulo = "Duna",
                    AutorDiretor = "Frank Herbert",
                    AnoLancamento = 1965,
                    Genero = "Ficção Científica",
                    Sinopse = "A jornada de um jovem nobre em um planeta desértico perigoso para garantir o futuro de seu povo.",
                    TipoMidia = TipoMidia.Livro
                },

                new ItemMidia
                {
                    Id = 3,
                    Titulo = "O Poderoso Chefão",
                    AutorDiretor = "Francis Ford Coppola",
                    AnoLancamento = 1972,
                    Genero = "Crime, Drama",
                    Sinopse = "O patriarca de uma dinastia do crime organizado transfere o controle de seu império clandestino para seu filho relutante.",
                    TipoMidia = TipoMidia.Filme
                },
                new ItemMidia
                {
                    Id = 4,
                    Titulo = "Interestelar",
                    AutorDiretor = "Christopher Nolan",
                    AnoLancamento = 2014,
                    Genero = "Ficção Científica, Aventura",
                    Sinopse = "Uma equipe de exploradores viaja através de um buraco de minhoca no espaço na tentativa de garantir a sobrevivência da humanidade.",
                    TipoMidia = TipoMidia.Filme
                },

                new ItemMidia
                {
                    Id = 5,
                    Titulo = "Breaking Bad",
                    AutorDiretor = "Vince Gilligan",
                    AnoLancamento = 2008,
                    Genero = "Crime, Drama, Suspense",
                    Sinopse = "Um professor de química do ensino médio diagnosticado com câncer de pulmão inoperável passa a produzir e vender metanfetamina para garantir o futuro de sua família.",
                    TipoMidia = TipoMidia.Serie
                },
                new ItemMidia
                {
                    Id = 6,
                    Titulo = "The Office (US)",
                    AutorDiretor = "Greg Daniels",
                    AnoLancamento = 2005,
                    Genero = "Comédia",
                    Sinopse = "Um documentário sobre o dia a dia cômico e, por vezes, tocante dos funcionários de uma empresa de papel.",
                    TipoMidia = TipoMidia.Serie
                }
            );
        }
    }
}