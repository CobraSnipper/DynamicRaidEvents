using DynamicRaidEvents.Models;

namespace DynamicRaidEvents.Core;

public sealed class RaidDirector
{
    private readonly IReadOnlyList<RaidEvent> events;

    public RaidDirector()
    {
        events = EventRegistry.GetEvents();
    }

    public RaidEvent SelectEvent()
    {
        var enabledEvents = events
            .Where(raidEvent => raidEvent.Enabled && raidEvent.Weight > 0)
            .ToList();

        if (enabledEvents.Count == 0)
        {
            throw new InvalidOperationException(
                "No enabled raid events with a positive weight were found.");
        }

        var totalWeight = enabledEvents.Sum(raidEvent => raidEvent.Weight);
        var roll = Random.Shared.Next(totalWeight);

        foreach (var raidEvent in enabledEvents)
        {
            if (roll < raidEvent.Weight)
            {
                return raidEvent;
            }

            roll -= raidEvent.Weight;
        }

        return enabledEvents[^1];
    }
}