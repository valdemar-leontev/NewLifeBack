using Microsoft.EntityFrameworkCore;
using NewLifeDAL.DataModels;

namespace NewLifeDataAccess.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<PhotoDataModel> Photos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PhotoDataModel>(entity => 
            entity.HasKey(p => p.Id));
    }
}