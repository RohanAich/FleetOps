namespace FleetOps.Domain.ValueObjects;

public sealed class Capacity 
{
    public int Kilograms { get; }

    public Capacity(int kilograms) 
    {
        if (kilograms < 0) 
        {
            throw new ArgumentOutOfRangeException(nameof(kilograms), "Capacity must be positive.");
        }

        this.Kilograms = kilograms;
    }
}
