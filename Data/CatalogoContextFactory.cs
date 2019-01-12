using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CatalogoProduto.Data
{
    public class CatalogoContextFactory : IDesignTimeDbContextFactory<CatalagoContext>
    {
        private readonly string ConnectionString = "Server=tcp:dbcatalogo2.database.windows.net,1433;Initial Catalog=catalogo;Persist Security Info=False;User ID={dbcatalogo2};Password={Misilva@123};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public CatalagoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalagoContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            return new CatalagoContext(ConnectionString);
        }
    }
}