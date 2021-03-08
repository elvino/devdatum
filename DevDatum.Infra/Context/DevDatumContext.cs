using DevDatum.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevDatum.Infra.Context
{
    public class DevDatumContext : DbContext
    {
        public DevDatumContext(DbContextOptions<DevDatumContext> options)
            : base(options) {}

        public DbSet<Fees> Fees { get; set; }
        public DbSet<Interest> Interest { get; set; }
    }
}
