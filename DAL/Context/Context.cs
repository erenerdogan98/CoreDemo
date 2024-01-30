using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DAL.Context
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-57R498V\\SQLEXPRESS01;database=CoreBlogDb; integrated security=true; TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(w => w.WriterSender)
                .HasForeignKey(y => y.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(w => w.WriterReceiver)
                .HasForeignKey(y => y.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder); // to for identity .. 
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet <BlogRating> BlogRatings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet <Message> Messages { get; set; }
        public DbSet <Message2> Message2s { get; set; }
        public DbSet <Admin> Admins { get; set; }
    }
}
