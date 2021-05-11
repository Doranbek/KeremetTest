using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeremetTest.Data
{
    public class KeremetDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public KeremetDbContext(DbContextOptions<KeremetDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //
            optionsBuilder.UseSqlServer(@"Server=DORON-PC\\SQLEXPRESS; Database = Keremet; Integrated Security=True;");
        }

    }

}


