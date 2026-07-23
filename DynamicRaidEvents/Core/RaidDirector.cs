using DynamicRaidEvents.Models;

namespace DynamicRaidEvents.Core;

public sealed class RaidDirector
{
    private readonly IReadOnlyList<RaidEvent> events;

    public RaidDirector()
    {
        events = EventRegistry.GetEvents();
    }

    public RaidEvent SelectEvent(int eventChance)
    {
        eventChance = Math.Clamp(eventChance, 0, 100);

        var normalRaid = events.FirstOrDefault(
            raidEvent => raidEvent.Id == "normal");

        if (normalRaid is null)
        {
            throw new InvalidOperationException(
                "The Normal Raid event is missing from EventRegistry.");
        }

        var eventRoll = Random.Shared.Next(1, 101);

        if (eventRoll > eventChance)
        {
            return normalRaid;
        }

        var specialEvents = events
            .Where(raidEvent =>
                raidEvent.Enabled &&
                raidEvent.Weight > 0 &&
                raidEvent.Id != "normal")
            .ToList();

        if (specialEvents.Count == 0)
        {
            return normalRaid;
        }

        var totalWeight = specialEvents.Sum(
            raidEvent => raidEvent.Weight);

        var weightedRoll = Random.Shared.Next(totalWeight);

        foreach (var raidEvent in specialEvents)
        {
            if (weightedRoll < raidEvent.Weight)
            {
                return raidEvent;
            }

            weightedRoll -= raidEvent.Weight;
        }

        return specialEvents[^1];
    }
}