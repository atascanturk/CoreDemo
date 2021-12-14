using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.Contexts
{
    public class Context :DbContext
    {       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CoreBlogDb; Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Message2>().HasOne(x => x.Sender).WithMany(y => y.SentMessages).HasForeignKey(z => z.SenderId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Message2>().HasOne(x => x.Receiver).WithMany(y => y.ReceivedMessages).HasForeignKey(z => z.ReceiverId).OnDelete(DeleteBehavior.ClientSetNull);
        }

        //DbSet
        public DbSet<About> Abouts{ get; set; }
        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Writer> Writers{ get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<BlogRate> BlogRates { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message2> Messages { get; set; }
        public DbSet<Admin> Admins { get; set; }
 
    }
}
