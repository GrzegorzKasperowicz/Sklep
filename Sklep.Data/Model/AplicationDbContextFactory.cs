using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Sklep.Data.Model
{
    public class AplicationDbContextFactory : IDesignTimeDbContextFactory<SklepDbContext>
    {
        public SklepDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SklepDbContext>();
            optionsBuilder.UseSqlServer("Data Source=GRJEGOSZ;Initial Catalog=Sklep;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return new SklepDbContext(optionsBuilder.Options);
        }
    }
}