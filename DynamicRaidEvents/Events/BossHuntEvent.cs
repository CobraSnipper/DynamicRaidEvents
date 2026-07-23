using DynamicRaidEvents.Models;

namespace DynamicRaidEvents.Events;

public sealed class BossHuntEvent : RaidEvent
{
    public BossHuntEvent()
        : base(
            id: "boss_hunt",
            name: "Boss Hunt",
            description: "A dangerous boss encounter is active.",
            weight: 25)
    {
    }
}