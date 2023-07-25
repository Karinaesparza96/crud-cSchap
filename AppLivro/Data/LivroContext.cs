using Microsoft.EntityFrameworkCore;

namespace AppLivro.Data
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> options) : base(options) { }

        public DbSet<Models.Livro> Livros { get; set; }
        public DbSet<Models.Autor> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Models.Livro>().ToTable("Livro");
            modelBuilder.Entity<Models.Autor>().ToTable("Autor");
        }
    }
}
