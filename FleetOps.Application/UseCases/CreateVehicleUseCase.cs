
using FleetOps.Application.DTOs;
using FleetOps.Application.Interfaces;
using FleetOps.Domain.Entities;
using FleetOps.Domain.ValueObjects;

namespace FleetOps.Application.UseCases;

public sealed class CreateVehicleUseCase
{
    private readonly IVehicleRepository _vehicleRepository;

    public CreateVehicleUseCase(IVehicleRepository vehicleRepository) 
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<CreateVehicleResponse> ExecuteAsync(CreateVehicleRequest request, CancellationToken cancellationToken = default) 
    {
        var capacity = new Capacity(request.Capacity);
        Vehicle vehicle = Vehicle.Create(request.Registration, capacity);

        await _vehicleRepository.AddAsync(vehicle, cancellationToken);

        return new CreateVehicleResponse
        {
            VehicleID = vehicle.Id
        };

    }

}
