public sealed class RescueCharacterFactory : ICharacterFactory
{
    public INPC Create(SpawnRequirements requirements)
    {
        return requirements.Time == TimeOfDay.Day ? (INPC)new RescueWorker() : new ShelterKeeper();
    }
}
