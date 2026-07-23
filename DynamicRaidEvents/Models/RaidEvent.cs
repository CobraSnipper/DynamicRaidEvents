namespace DynamicRaidEvents.Models;

public sealed class RaidEvent
{
    public required string Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public int Weight { get; init; } = 1;
}