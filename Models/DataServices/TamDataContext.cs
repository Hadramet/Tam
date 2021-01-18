using Microsoft.EntityFrameworkCore;

namespace Tam.webapp.Models.DataServices
{
    public class TamDataContext : DbContext
    {
        public DbSet<TPlayList> PlayLists { get; set; }

        public TamDataContext(DbContextOptions<TamDataContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
