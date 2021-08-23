using Microsoft.EntityFrameworkCore;
using Clinicas.Models.Clinica;

namespace Clinicas.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<EnderecoClinica> EnderecoClinica { get; set; }
        public DbSet<ContatoClinica> ContatoClinica { get; set; }
    }
}
