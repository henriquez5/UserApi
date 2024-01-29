using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserApi.Model;

namespace UserApi.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Users>().HasKey(x => x.ID_USER).HasName("PK_USERS");
        }

        public virtual DbSet<Users> Users { get; set; }

    }
}
