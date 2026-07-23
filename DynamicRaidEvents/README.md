# Dynamic Raid Events

A configurable server-side mod for **SPT 4.0.x** that adds dynamic raid events with a scalable, modular architecture designed for future gameplay expansion.

---

## Current Version

**v0.0.7**

---

## Supported Version

- **SPT 4.0.x**
- .NET 9

---

## Features

- ✅ Automatic `config.json` generation
- ✅ Enable or disable the mod through configuration
- ✅ Configurable event chance (0–100%)
- ✅ Weighted random event selection
- ✅ Automatic fallback to **Normal Raid**
- ✅ Modular event architecture
- ✅ Individual event classes
- ✅ Event execution framework using `Apply()`
- ✅ Shared `RaidContext` system
- ✅ Automatic recovery from invalid configuration files

---

## Current Raid Events

| Event | Description |
|--------|-------------|
| Normal Raid | No special event is active. |
| Boss Hunt | A dangerous boss encounter is active. |
| Boss Convention | Multiple bosses have appeared. |
| Loot Surge | Loot quality has increased. |

> **Note:**  
> These events currently demonstrate the event framework and execution pipeline. Gameplay modifications will be introduced in future releases.

---

## Configuration

The mod automatically generates a `config.json` file on first launch.

Example:

```json
{
  "Enabled": true,
  "EventChance": 100
}
```

### Configuration Options

| Setting | Description |
|---------|-------------|
| Enabled | Enables or disables the mod. |
| EventChance | Percentage chance (0–100) that a special raid event will occur. |

---

## Project Structure

```text
DynamicRaidEvents
├── Config
│   └── DynamicRaidEventsConfig.cs
├── Core
│   ├── EventRegistry.cs
│   └── RaidDirector.cs
├── Events
│   ├── NormalRaidEvent.cs
│   ├── BossHuntEvent.cs
│   ├── BossConventionEvent.cs
│   └── LootSurgeEvent.cs
├── Managers
│   └── ConfigManager.cs
├── Models
│   ├── IRaidEvent.cs
│   ├── RaidContext.cs
│   └── RaidEvent.cs
└── DynamicRaidEventsMod.cs
```

---

## How It Works

1. The mod loads its configuration.
2. The configured event chance is evaluated.
3. A weighted random raid event is selected.
4. The selected event executes its own `Apply()` method.
5. Event information is written to the server log.

This architecture allows each raid event to manage its own behavior independently without modifying the core selection system.

---

## Development Progress

| Version | Status |
|---------|--------|
| ✅ v0.0.1 | Initial project setup |
| ✅ v0.0.2 | Weighted event selection |
| ✅ v0.0.3 | Event registry system |
| ✅ v0.0.4 | Configuration system |
| ✅ v0.0.5 | Configurable event chance |
| ✅ v0.0.6 | Modular event architecture |
| ✅ v0.0.7 | Event execution framework |
| 🚧 Next | First gameplay event implementation |

---

## Roadmap

### v0.0.x
- Gameplay event execution
- Loot event implementation
- Boss spawn event implementation

### v0.1.x
- Weather events
- AI behavior events
- Map-specific events
- Day/Night event restrictions

### v0.5.x
- Advanced event filtering
- Event chaining
- Expanded configuration options

### v1.0.0
- Stable gameplay framework
- Fully configurable dynamic raid events
- Multiple event categories
- Complete documentation

---

## License

This project is licensed under the **MIT License**.

---

## Author

**Cobra**

GitHub:
https://github.com/CobraSnipper