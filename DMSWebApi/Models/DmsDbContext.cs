
using DMSClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace DMSWebApi.Models
{
    public class DmsDbContext: DbContext
    {
        public DmsDbContext(DbContextOptions<DmsDbContext> dboptions) : base(dboptions)
        {

        }
        public DbSet<cd_provinces> cd_provinces { get; set; }
        public DbSet<daycares> daycares { get; set; }
        public DbSet<system_access_levels> system_access_levels { get; set; }
        public DbSet<system_accounts> system_accounts { get; set; }
        public DbSet<dms_api_key> dms_api_key { get; set; }
    }
}
