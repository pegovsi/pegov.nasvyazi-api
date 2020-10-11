using Microsoft.EntityFrameworkCore;
namespace Pegov.Nasvyazi.Persistence.Postgres
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
            => new AppDbContext(options);
    }
}
