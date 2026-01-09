using FleetOps.Application.DTOs;
using FleetOps.Application.Interfaces;
using FleetOps.Application.UseCases;
using FleetOps.Domain.Entities;
using FluentAssertions;
using Moq;

namespace FleetOps.Application.Tests.UseCasesTests;

public class CreateVehicleUseCaseTests
{
    [Fact]
    public async Task ExecuteAsync_WithValidRequest_ShouldPersistVehicle()
    {
        var repo = new Mock<IVehicleRepository>();
        var useCase = new CreateVehicleUseCase(repo.Object);

        var request = new CreateVehicleRequest
        {
            Registration = "ghi-123",
            Capacity = 1000
        };

        var response = await useCase.ExecuteAsync(request);

        // Assertions
        response.VehicleID.Should().NotBe(default);

        repo.Verify(r => r.AddAsync(
            It.Is<Vehicle>(v =>
                v.Registration == "GHI-123" &&
                v.Capacity.Kilograms == 1000
            ),
            It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
