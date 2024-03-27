using Microsoft.EntityFrameworkCore;

namespace URLShortener.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public DBSet<ShortUrl> shortUrls { get; set; } = null!;
    }
}
