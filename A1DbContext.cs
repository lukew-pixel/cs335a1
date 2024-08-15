using Microsoft.EntityFrameworkCore;
using A1Template.Models;

namespace A1Template.Data
{
    public class A1DbContext : DbContext
    {
        public A1DbContext(DbContextOptions<A1DbContext> options) : base(options) { }

        public DbSet<Sign> Signs { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
