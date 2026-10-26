public enum TimeOfDay { Day, Night }
public enum VillageSafety { Peaceful, Threatened }
public enum Weather { Clear, Storm }

// A snapshot of the three choices made by the user.
public sealed class SpawnRequirements
{
    public Weather Weather { get; }
    public TimeOfDay Time { get; }
    public VillageSafety Safety { get; }

    public SpawnRequirements(TimeOfDay time, VillageSafety safety, Weather weather = Weather.Clear)
    {
        if (!System.Enum.IsDefined(typeof(TimeOfDay), time))
            throw new System.ArgumentOutOfRangeException(nameof(time));
        if (!System.Enum.IsDefined(typeof(VillageSafety), safety))
            throw new System.ArgumentOutOfRangeException(nameof(safety));
        if (!System.Enum.IsDefined(typeof(Weather), weather))
            throw new System.ArgumentOutOfRangeException(nameof(weather));
        Weather = weather;
        Time = time;
        Safety = safety;
    }
}
