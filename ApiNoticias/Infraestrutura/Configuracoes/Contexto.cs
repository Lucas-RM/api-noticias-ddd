using Entidades.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Configuracoes
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }

        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            string stringConexao = "Data Source=LUCAS\\DESENVOLVIMENTO;Initial Catalog=API_NOTICIAS_DDD;Integrated Security=False;User ID=sa;Password=LU5830mar03*;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return stringConexao;
        }
    }
}
