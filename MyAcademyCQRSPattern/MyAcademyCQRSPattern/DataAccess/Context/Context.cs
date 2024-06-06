using Microsoft.EntityFrameworkCore;
using MyAcademyCQRSPattern.DataAccess.Entities;

namespace MyAcademyCQRSPattern.DataAccess.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=CAGLA\\SQLEXPRESS;database=MyAcademyCQRSPatternDb;integrated security=true;trustServerCertificate=true"); //burada bağlantı adresimi gerçiyorum.
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
