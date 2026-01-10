using FleetOps.Domain.ValueObjects;

namespace FleetOps.Domain.Entities;

public class Vehicle
{
    public VehicleID Id { get; }
    public string? Registration { get; }
    public Capacity Capacity { get; }
    public VehicleStatus Status { get; private set; }

    private Vehicle(VehicleID id, string? registration, Capacity capacity)
    {
        Id = id;
        Registration = registration;
        Capacity = capacity;
        Status = VehicleStatus.Available;
    }

    private Vehicle() { }

    public static Vehicle Create(string registration, Capacity capacity)
    {
        if (string.IsNullOrEmpty(registration))
            throw new ArgumentException("Registration is required", nameof(registration));

        return new Vehicle(VehicleID.New(), registration.Trim().ToUpperInvariant(), capacity);
    }

    public void Assign() 
    {
        if (Status != VehicleStatus.Available)
            throw new InvalidOperationException("Vehicle is not available for assignment");

        Status = VehicleStatus.Assigned;
    }

    public void DesignateOutOfService() 
    {
        Status = VehicleStatus.OutOfService;
    }
}
