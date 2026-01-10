
using FleetOps.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FleetOps.Infrastructure.Persistence;

public static class VehicleConverters
{
    public static readonly ValueConverter<VehicleID, Guid> VehicleIdConverter =
    new(v => v.Value, v => new VehicleID(v));
}
