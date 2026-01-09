namespace FleetOps.Domain.ValueObjects;

public readonly record struct VehicleID(Guid Value) 
{
    public static VehicleID New() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}
