using DynamicRaidEvents.Models;

namespace DynamicRaidEvents.Events;

public sealed class NormalRaidEvent : RaidEvent
{
    public NormalRaidEvent()
        : base(
            id: "normal",
            name: "Normal Raid",
            description: "No special event is active.",
            weight: 50)
    {
    }
}