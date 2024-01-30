using Microsoft.EntityFrameworkCore;

namespace BlogCoreDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-57R498V\\SQLEXPRESS01;database=CoreBlogApiDb; integrated security=true; TrustServerCertificate=true;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
