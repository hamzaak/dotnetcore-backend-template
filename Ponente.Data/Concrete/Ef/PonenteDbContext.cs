using Microsoft.EntityFrameworkCore;
using Ponente.Entity.Concrete;

namespace Ponente.Data.Concrete.Ef
{
    public class PonenteDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Directory> Directories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=ponente;user=root;password=Hmzk8811");
        }
    }
}
