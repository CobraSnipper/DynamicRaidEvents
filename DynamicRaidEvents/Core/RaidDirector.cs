using DynamicRaidEvents.Models;

namespace DynamicRaidEvents.Core;

public sealed class RaidDirector
{
    private readonly List<RaidEvent> _events =
    [
        new RaidEvent
        {
            Id = "normal_raid",
            Name = "Normal Raid",
            Description = "No special event is active.",
            Weight = 50
        },

        new RaidEvent
        {
            Id = "boss_hunt",
            Name = "Boss Hunt",
            Description = "A dangerous boss encounter is active.",
            Weight = 25
        },

        new RaidEvent
        {
            Id = "boss_convention",
            Name = "Boss Convention",
            Description = "Multiple bosses may appear during the raid.",
            Weight = 10
        },

        new RaidEvent
        {
            Id = "loot_surge",
            Name = "Loot Surge",
            Description = "The raid contains increased valuable loot.",
            Weight = 15
        }
    ];

    public RaidEvent SelectRandomEvent()
    {
        var totalWeight = _events.Sum(raidEvent => raidEvent.Weight);
        var roll = Random.Shared.Next(1, totalWeight + 1);

        var currentWeight = 0;

        foreach (var raidEvent in _events)
        {
            currentWeight += raidEvent.Weight;

            if (roll <= currentWeight)
            {
                return raidEvent;
            }
        }

        return _events[0];
    }
}