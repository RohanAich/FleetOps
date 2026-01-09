using FleetOps.Domain.Entities;
using FleetOps.Domain.ValueObjects;
using FleetOps.Application.Interfaces;

namespace FleetOps.Infrastructure.Persistence;

public sealed class InMemoryVehicleRepository : IVehicleRepository
{
    private readonly Dictionary<VehicleID, Vehicle> _store = new();

    public Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default) 
    {
        _store[vehicle.Id] = vehicle;
        return Task.CompletedTask;
    }

    public Task<Vehicle?> GetByIdAsync(VehicleID id, CancellationToken cancellationToken = default) 
    {
        _store.TryGetValue(id, out var vehicle);
        return Task.FromResult(vehicle);
    }
}
