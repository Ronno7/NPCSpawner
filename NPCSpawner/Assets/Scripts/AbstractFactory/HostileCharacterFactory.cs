public sealed class HostileCharacterFactory : ICharacterFactory
{
    public INPC Create(SpawnRequirements requirements)
    {
        return requirements.Time == TimeOfDay.Day ? (INPC)new Raider() : new Infiltrator();
    }
}
