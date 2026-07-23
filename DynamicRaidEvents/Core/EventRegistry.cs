using DynamicRaidEvents.Events;
using DynamicRaidEvents.Models;

namespace DynamicRaidEvents.Core;

public static class EventRegistry
{
    public static IReadOnlyList<RaidEvent> GetEvents()
    {
        return
        [
            new NormalRaidEvent(),
            new BossHuntEvent(),
            new BossConventionEvent(),
            new LootSurgeEvent()
        ];
    }
}