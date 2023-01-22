using BRC.Models;
using Microsoft.EntityFrameworkCore;

namespace BRC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
                
        }
        public DbSet<BookReview> BookReview { get; set; }
    }
}
