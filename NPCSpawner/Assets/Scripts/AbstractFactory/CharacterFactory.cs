// Follows Woodfine's refactored factory: requirements select the concrete factory.
public sealed class CharacterFactory : AbstractCharacterFactory
{
    private readonly SpawnRequirements requirements;
    private readonly ICharacterFactory factory;

    public CharacterFactory(SpawnRequirements requirements)
    {
        this.requirements = requirements ?? throw new System.ArgumentNullException(nameof(requirements));
        factory = requirements.Weather == Weather.Storm
            ? new RescueCharacterFactory()
            : requirements.Safety == VillageSafety.Peaceful
            ? (ICharacterFactory)new FriendlyCharacterFactory()
            : new HostileCharacterFactory();
    }

    public override INPC Create() => factory.Create(requirements);
}
