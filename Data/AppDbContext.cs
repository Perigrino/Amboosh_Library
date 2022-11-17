using Amboosh_Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Amboosh_Library.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasOne(b => b.Book)
            .WithMany(ba => ba.BookAuthors)
            .HasForeignKey(bi => bi.BookId);
        
        modelBuilder.Entity<BookAuthor>()
            .HasOne(b => b.Author)
            .WithMany(ba => ba.BookAuthors)
            .HasForeignKey(bi => bi.AuthorId);
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> Book_Authors { get; set; }
}