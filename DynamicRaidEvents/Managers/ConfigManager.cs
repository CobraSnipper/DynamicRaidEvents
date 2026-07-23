using System.Reflection;
using System.Text.Json;
using DynamicRaidEvents.Config;

namespace DynamicRaidEvents.Managers;

public sealed class ConfigManager
{
    private const string ConfigFileName = "config.json";

    private readonly string configPath;

    public ConfigManager()
    {
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var modDirectory = Path.GetDirectoryName(assemblyLocation);

        if (string.IsNullOrWhiteSpace(modDirectory))
        {
            throw new InvalidOperationException(
                "The Dynamic Raid Events mod directory could not be determined.");
        }

        configPath = Path.Combine(modDirectory, ConfigFileName);
    }

    public DynamicRaidEventsConfig Config { get; private set; } = new();

    public void Load()
    {
        if (!File.Exists(configPath))
        {
            Save();
            return;
        }

        try
        {
            var json = File.ReadAllText(configPath);

            Config =
                JsonSerializer.Deserialize<DynamicRaidEventsConfig>(json)
                ?? new DynamicRaidEventsConfig();
        }
        catch (JsonException)
        {
            Config = new DynamicRaidEventsConfig();
            Save();

            throw new InvalidOperationException(
                $"The configuration file was invalid and has been reset: {configPath}");
        }
    }

    public void Save()
    {
        var json = JsonSerializer.Serialize(
            Config,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(configPath, json);
    }
}