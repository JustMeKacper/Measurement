using Microsoft.EntityFrameworkCore;

namespace Measurement.Entities
{
    public class DataContext:DbContext
    {
        private readonly string _connectionString = "DataSource = RelativeSqlBase.db";
        public DbSet<Measurement> Measurement { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Progress> Progress{ get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Task> Task{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite(_connectionString);
        }
    }
}
