using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;

namespace NewsPortal.Data
{
    public class NewsPortalContext : DbContext
    {
        public NewsPortalContext(DbContextOptions<NewsPortalContext> options) : base(options) { }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}