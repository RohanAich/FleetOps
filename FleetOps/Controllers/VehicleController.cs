using FleetOps.Application.DTOs;
using FleetOps.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace FleetOps.Controllers;

[ApiController]
[Route("api/vehicles")]
public sealed class VehicleController : ControllerBase
{
    private readonly CreateVehicleUseCase _createVehicle;

    public VehicleController(CreateVehicleUseCase createVehicle) {  _createVehicle = createVehicle; }

    [HttpPost]
    public async Task<IActionResult> Create ([FromBody] CreateVehicleRequest request, CancellationToken cancellationToken) 
    {
        var result = await _createVehicle.ExecuteAsync(request, cancellationToken);

        return CreatedAtAction(nameof(Create), new { id = result.VehicleID.Value }, result);
    }
}
