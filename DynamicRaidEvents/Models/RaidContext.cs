namespace DynamicRaidEvents.Models;

public sealed class RaidContext
{
    public required Action<string> LogInfo { get; init; }
}