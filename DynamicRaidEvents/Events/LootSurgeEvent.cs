using DynamicRaidEvents.Models;

namespace DynamicRaidEvents.Events;

public sealed class LootSurgeEvent : RaidEvent
{
    public LootSurgeEvent()
        : base(
            id: "loot_surge",
            name: "Loot Surge",
            description: "Loot quality has increased.",
            weight: 15)
    {
    }
}