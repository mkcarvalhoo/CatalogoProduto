using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Data
{
    public class CatalagoContext : DbContext
    {

         private readonly IConfiguration Configuration;
        private readonly string ConnectionString;

        public CatalagoContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public CatalagoContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CatalogoSQL"));
            else
                optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
