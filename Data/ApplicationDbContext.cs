// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using MyRestApi.Models;

namespace MyRestApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Prepod> Prepods { get; set; }
        public DbSet<Predmet> Predmets { get; set; }
        public DbSet<PredmetPrepod> PredmetPrepods { get; set; }
        public DbSet<Groop> Groops { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Zachisl> Zachisls { get; set; }
        public DbSet<Kt> Kts { get; set; }
        public DbSet<MarkKt> MarkKts { get; set; }
        public DbSet<TipAud> TipAuds { get; set; }
        public DbSet<Auditor> Auditors { get; set; }
        public DbSet<Ekzamen> Ekzamens { get; set; }
        public DbSet<Raspisanie> Raspisanies { get; set; }
    }
}