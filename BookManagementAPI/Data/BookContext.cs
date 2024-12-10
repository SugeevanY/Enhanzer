using Microsoft.EntityFrameworkCore;
using BookManagementAPI.Models;

namespace BookManagementAPI.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
