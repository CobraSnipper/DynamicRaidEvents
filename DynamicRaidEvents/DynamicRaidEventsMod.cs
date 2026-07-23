using DynamicRaidEvents.Core;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Utils;
using DynamicRaidEvents.Managers;

namespace DynamicRaidEvents;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; }
        = "com.Cobra.dynamicraidevents";

    public override string Name { get; init; }
        = "Dynamic Raid Events";

    public override string Author { get; init; }
        = "Cobra";

    public override List<string>? Contributors { get; init; }

    public override SemanticVersioning.Version Version { get; init; }
        = new("0.0.6");

    public override SemanticVersioning.Range SptVersion { get; init; }
        = new("~4.0.0");

    public override List<string>? Incompatibilities { get; init; }

    public override Dictionary<string, SemanticVersioning.Range>?
        ModDependencies
    { get; init; }

    public override string? Url { get; init; }

    public override bool? IsBundleMod { get; init; }

    public override string License { get; init; }
        = "MIT";
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader)]
public sealed class DynamicRaidEventsMod(
    ISptLogger<DynamicRaidEventsMod> logger) : IOnLoad
{
    public Task OnLoad()
    {
        var configManager = new ConfigManager();
        configManager.Load();

        logger.Success("[Dynamic Raid Events] v0.0.6 loaded successfully!");
        logger.Info($"[Dynamic Raid Events] Configuration loaded. Enabled: {configManager.Config.Enabled}, Event chance: {configManager.Config.EventChance}%");

        if (!configManager.Config.Enabled)
        {
            logger.Warning("[Dynamic Raid Events] The mod is disabled in config.json.");
            return Task.CompletedTask;
        }

        var raidDirector = new RaidDirector();
        var selectedEvent = raidDirector.SelectEvent(configManager.Config.EventChance);

        logger.Info($"[Dynamic Raid Events] Event selected: {selectedEvent.Name}");
        logger.Info($"[Dynamic Raid Events] Description: {selectedEvent.Description}");

        return Task.CompletedTask;
    }
}