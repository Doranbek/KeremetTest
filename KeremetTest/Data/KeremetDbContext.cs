using Microsoft.EntityFrameworkCore;

namespace KeremetTest.Data
{
    public class KeremetDbContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Client> Clients { get; set; }        

        public KeremetDbContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlServer(_connectionString);
    }    

}




