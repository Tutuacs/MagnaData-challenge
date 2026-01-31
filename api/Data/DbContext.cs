namespace api.Data;

using api.Model.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<TodoDb> Todo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<TodoDb>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(CURRENT_DATE)");
        });
    }
}