using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApiDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorBook>()
          .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<AuthorBook>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.AuthorBook)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<AuthorBook>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.AuthorBook)
                .HasForeignKey(ba => ba.AuthorId);

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AuthorBook>()
        //                .HasKey(ba => new { ba.BookId, ba.AuthorId });

        //    modelBuilder.Entity<AuthorBook>()
        //                .HasOne(ba => ba.Book)
        //                .WithMany(b => b.AuthorBook)
        //                .HasForeignKey(ba => ba.BookId)
        //                .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<AuthorBook>()
        //                .HasOne(ba => ba.Author)
        //                .WithMany(a => a.AuthorBook)
        //                .HasForeignKey(ba => ba.AuthorId)
        //                .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
