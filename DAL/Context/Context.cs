using Microsoft.EntityFrameworkCore;


namespace DAL.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-57R498V\\SQLEXPRESS01;database=CoreBlogDb; integrated security=true");
        }
    }
}
