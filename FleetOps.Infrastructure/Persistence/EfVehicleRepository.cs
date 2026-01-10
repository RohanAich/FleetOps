using FleetOps.Application.Interfaces;
using FleetOps.Domain.Entities;
using FleetOps.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace FleetOps.Infrastructure.Persistence;

public sealed class EfVehicleRepository : IVehicleRepository
{
    private readonly FleetOpsDbContext _dbContext;

    public EfVehicleRepository(FleetOpsDbContext dbContext) {  _dbContext = dbContext; }

    public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
    {
        _dbContext.Vehicles.Add(vehicle);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Vehicle?> GetByIdAsync(VehicleID id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Vehicles
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
    }
}
