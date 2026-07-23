# Changelog

## v0.0.6

- Converted RaidEvent into an abstract base class
- Added individual event classes
- Added NormalRaidEvent
- Added BossHuntEvent
- Added BossConventionEvent
- Added LootSurgeEvent
- Simplified EventRegistry
- Preserved existing weighted event-selection behavior


## v0.0.5

- Connected EventChance to raid event selection
- Added 0–100 configuration value clamping
- Normal Raid is selected when the event roll fails
- Special events are selected using weighted random selection
- Normal Raid is excluded from the special-event pool
- Added fallback behavior when no valid special events are available

## v0.0.4

- Added DynamicRaidEventsConfig
- Added ConfigManager
- Added automatic config.json creation
- Added mod enable/disable setting
- Added configurable event chance setting
- Added invalid JSON recovery
- Configuration is stored beside the mod DLL

## v0.0.3

- Added EventRegistry
- Moved raid event definitions out of RaidDirector
- Added event enable/disable support
- RaidDirector now ignores disabled events
- RaidDirector now ignores events with zero or negative weight
- Refactored event system for future expansion

## v0.0.2

- Added RaidEvent model
- Added RaidDirector
- Added weighted event selection
- Added event descriptions
- Initial GitHub repository

## v0.0.1

- Initial project
- Mod loads successfully