using Microsoft.EntityFrameworkCore;
using DancePage.Model;

namespace DancePage.Data
{
    public class DanceDbContext : DbContext
    {
        public DanceDbContext(DbContextOptions<DanceDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<GifsInfo> Gifsinfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Dance-Api;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
