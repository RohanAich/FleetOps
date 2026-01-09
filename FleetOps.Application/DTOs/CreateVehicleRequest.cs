
namespace FleetOps.Application.DTOs;

public sealed class CreateVehicleRequest
{
    public string Registration { get; init; } = string.Empty;
    public int Capacity { get; init; }
}
