using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Composition.Convention;

namespace ArcticBook.Models.Domain
{
    public class DatabaseContext :IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Manga> Manga { get; set; }
        public DbSet<BookManga> BookManga { get; set; }
    }
}
