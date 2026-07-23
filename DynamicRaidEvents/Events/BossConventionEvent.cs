using DynamicRaidEvents.Models;

namespace DynamicRaidEvents.Events;

public sealed class BossConventionEvent : RaidEvent
{
    public BossConventionEvent()
        : base(
            id: "boss_convention",
            name: "Boss Convention",
            description: "Multiple bosses have appeared.",
            weight: 10)
    {
    }
}