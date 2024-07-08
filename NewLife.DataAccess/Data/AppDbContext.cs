using Microsoft.EntityFrameworkCore;
using NewLife.DataAccess.DataModels;

namespace NewLife.DataAccess.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<FileDataModel> Files { get; set; }

    public virtual DbSet<EventDataModel> Events { get; set; }

    public virtual DbSet<EventRegistrationDataModel> EventRegistrations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // FileDataModel

        modelBuilder.Entity<FileDataModel>(entity =>
            entity.HasKey(f => f.Id));

        // EventDataModel

        modelBuilder.Entity<EventDataModel>(entity => entity
            .HasKey(e => e.Id)
        );

        modelBuilder.Entity<EventDataModel>(entity => entity
            .HasOne(e => e.File)
            .WithMany(f => f.Events)
            .HasForeignKey(e => e.FileId)
        );

        // EventRegistrationDataModel

        modelBuilder.Entity<EventRegistrationDataModel>(entity => entity
           .HasKey(e => e.Id)
        );

        modelBuilder.Entity<EventRegistrationDataModel>(entity => entity
            .HasOne(er => er.Event)
            .WithMany(e => e.EventRegistrations)
            .HasForeignKey(er => er.EventId)
        );
    }
}