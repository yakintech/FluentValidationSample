using Microsoft.EntityFrameworkCore;

namespace FluentValidationSample.Models.ORM
{
    public class AkademiIstanbulContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EET2RGT;Database=AkademiIstanbul;Trusted_Connection=True; trustServerCertificate=true");
        }

        public DbSet<Student> Students { get; set; }
    }
}
