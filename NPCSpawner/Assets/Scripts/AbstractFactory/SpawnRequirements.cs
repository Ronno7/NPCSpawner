public enum TimeOfDay { Day, Night }
public enum VillageSafety { Peaceful, Threatened }

// A snapshot of the two choices made by the user.
public sealed class SpawnRequirements
{
    public TimeOfDay Time { get; }
    public VillageSafety Safety { get; }

    public SpawnRequirements(TimeOfDay time, VillageSafety safety)
    {
        if (!System.Enum.IsDefined(typeof(TimeOfDay), time))
            throw new System.ArgumentOutOfRangeException(nameof(time));
        if (!System.Enum.IsDefined(typeof(VillageSafety), safety))
            throw new System.ArgumentOutOfRangeException(nameof(safety));
        Time = time;
        Safety = safety;
    }
}
