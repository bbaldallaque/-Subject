using _Subject.Models;
using Microsoft.EntityFrameworkCore;

namespace _Subject
{
    public class SubjetContext : DbContext, ISubjetContext
    {
        public SubjetContext(DbContextOptions<SubjetContext> options) : base(options) { }

        public DbSet<Subjet> Subjets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subjet>(teacher =>
            {
                teacher.ToTable("Subjet");
                teacher.HasKey(x => x.Id);
                teacher.Property(x => x.SubjetName).IsRequired().HasMaxLength(50);              
            });
        }

        void ISubjetContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
