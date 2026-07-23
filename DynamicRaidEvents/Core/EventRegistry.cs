using DynamicRaidEvents.Models;

namespace DynamicRaidEvents.Core;

public static class EventRegistry
{
    public static IReadOnlyList<RaidEvent> GetEvents()
    {
        return
        [
            new RaidEvent(
                "normal",
                "Normal Raid",
                "No special event is active.",
                50),

            new RaidEvent(
                "boss_hunt",
                "Boss Hunt",
                "A dangerous boss encounter is active.",
                25),

            new RaidEvent(
                "boss_convention",
                "Boss Convention",
                "Multiple bosses have appeared.",
                10),

            new RaidEvent(
                "loot_surge",
                "Loot Surge",
                "Loot quality has increased.",
                15)
        ];
    }
}