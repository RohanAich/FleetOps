using FleetOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleetOps.Infrastructure.Persistence;

public sealed class FleetOpsDbContext : DbContext
{
    public FleetOpsDbContext(DbContextOptions<FleetOpsDbContext> options) : base(options) { }

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>(builder =>
        {
            builder.HasKey(v => v.Id);

            //Conversion
            builder.Property(v => v.Id).HasConversion(VehicleConverters.VehicleIdConverter);

            builder.Property(v => v.Registration).IsRequired().HasMaxLength(20);
            builder.OwnsOne(v => v.Capacity, cb =>
            {
                cb.Property(c => c.Kilograms).HasColumnName("Capacity").IsRequired();
            });
            builder.Property(v => v.Status).IsRequired();
        });
    }
}
