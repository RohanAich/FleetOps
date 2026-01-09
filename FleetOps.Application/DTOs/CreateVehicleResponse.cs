
using FleetOps.Domain.ValueObjects;

namespace FleetOps.Application.DTOs;

public sealed class CreateVehicleResponse
{
    public VehicleID VehicleID { get; init; }
}
