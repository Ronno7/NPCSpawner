public sealed class FriendlyCharacterFactory : ICharacterFactory
{
    public INPC Create(SpawnRequirements requirements)
    {
        return requirements.Time == TimeOfDay.Day ? (INPC)new Merchant() : new NightWatch();
    }
}
