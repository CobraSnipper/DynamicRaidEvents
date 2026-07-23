namespace DynamicRaidEvents.Models;

public interface IRaidEvent
{
    string Id { get; }

    string Name { get; }

    string Description { get; }

    int Weight { get; }

    bool Enabled { get; }

    void Apply(RaidContext context);
}