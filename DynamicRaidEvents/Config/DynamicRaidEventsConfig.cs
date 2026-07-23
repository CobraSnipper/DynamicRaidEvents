namespace DynamicRaidEvents.Config;

public sealed class DynamicRaidEventsConfig
{
    public bool Enabled { get; set; } = true;

    public int EventChance { get; set; } = 100;
}