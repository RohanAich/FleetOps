namespace FleetOps.Application.Interfaces;

using FleetOps.Domain.Entities;
using FleetOps.Domain.ValueObjects;

public interface IVehicleRepository
{
    Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default);
    Task<Vehicle?> GetByIdAsync(VehicleID id,  CancellationToken cancellationToken = default);
}
