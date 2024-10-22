using firstmvc.Models;
using Microsoft.EntityFrameworkCore;

namespace firstmvc.Data
{
    public class Applicationdbcontext : DbContext
    {

    public DbSet<Product>Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
"Data Source=.\\NEWMSSQLSERVER;" +
    "Initial Catalog=mvc1 ;" +
    "Integrated Security=True;" +
    "TrustServerCertificate=True");

        }
    }
}
