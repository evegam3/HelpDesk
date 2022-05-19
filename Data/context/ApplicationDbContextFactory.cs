using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<HelpDeskDbContext>
    {
        public HelpDeskDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HelpDeskDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VLO808K;Initial Catalog=HelpDesk;Integrated Security=True");

            return new HelpDeskDbContext(optionsBuilder.Options);
        }
    }
}
