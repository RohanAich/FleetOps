using FleetOps.Domain.Entities;
using FleetOps.Domain.ValueObjects;
using FluentAssertions;

namespace FleetOps.Domain.Tests.EntitiesTests;

public class VehicleTests
{
    [Fact]
    public void Create_WithValidData_ShouldCreateVehicle()
    {
        var capacity = new Capacity(1000);
        String vehicleName = "Test Vehicle";

        var vehicle = Vehicle.Create(vehicleName, capacity);

        //Assertions
        vehicle.Should().NotBeNull();
        vehicle.Id.Should().NotBe(default);
        vehicle.Registration.Should().Be(vehicleName.ToUpperInvariant());
        vehicle.Capacity.Should().Be(capacity);
        vehicle.Status.Should().Be(VehicleStatus.Available);
    }

    [Fact]
    public void Assign_WhenAvailable_ShouldChangeStatusToAssigned() 
    {
        Vehicle vehicle = Vehicle.Create("FGH-123", new Capacity(820));

        vehicle.Assign();

        //Assertions
        vehicle.Status.Should().Be(VehicleStatus.Assigned);
    }

    [Fact]
    public void Assign_WhenNotAvailable_ShouldThrow() 
    {
        var vehicle = Vehicle.Create("GHI-345", new Capacity(920));
        vehicle.DesignateOutOfService();

        var act = () => vehicle.Assign();

        //Assertions
        act.Should().Throw<InvalidOperationException>();
    }
}
