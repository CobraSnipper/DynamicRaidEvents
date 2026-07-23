namespace DynamicRaidEvents.Models;

public abstract class RaidEvent : IRaidEvent
{
    protected RaidEvent(
        string id,
        string name,
        string description,
        int weight,
        bool enabled = true)
    {
        Id = id;
        Name = name;
        Description = description;
        Weight = weight;
        Enabled = enabled;
    }

    public string Id { get; }

    public string Name { get; }

    public string Description { get; }

    public int Weight { get; }

    public bool Enabled { get; set; }

    public virtual void Apply(RaidContext context)
    {
    }
}