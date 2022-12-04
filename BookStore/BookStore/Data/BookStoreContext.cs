using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
                
        }

        public DbSet<Books> Books { get; set; }

        public DbSet<Language> Languages { get; set; }
    } 
}
