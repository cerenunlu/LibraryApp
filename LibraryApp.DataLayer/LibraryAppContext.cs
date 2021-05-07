using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace LibraryApp.DataLayer
{
    public class LibraryAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI;Database=Library;User Id=saceren;Password=1;", option =>
            {
                option.EnableRetryOnFailure();
            });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ENTUserBook>().HasKey(a => new { a.FK_UserID, a.FK_BookID });
            base.OnModelCreating(modelBuilder);
        }
       

        public DbSet<ENTUser> User { get; set; }
        public DbSet<ENTBook> Book { get; set; }
        public DbSet<ENTAuthor> Author { get; set; }
    }

}
