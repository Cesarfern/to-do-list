using CrudAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Tarea> Tareas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Title).HasMaxLength(50);
                tb.Property(col => col.Description).HasMaxLength(5000);
                tb.Property(col => col.IsCompleted);
                tb.Property(col => col.CreatedAt).HasDefaultValueSql("getdate()");
                tb.ToTable("Tarea");
            });
        }
    }
}
