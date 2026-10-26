# Spawn Systems ++

Unity abstract factory demo with three requirements: **time of day**, **village safety**, and **weather**.

## Added

- A weather selector and third concrete factory, `RescueCharacterFactory`.
- Storms prioritise rescue: Rescue Worker by day, Shelter Keeper by night. Clear weather uses the existing friendly or hostile factory.
- Up to six characters at once, with a Clear button. Existing characters keep their roles.
- A small platform, simple role props, muted group colours, and a quiet spawn tone.
- Visual and audio helpers moved into `SpawnPresentation` to keep them separate from factory decisions.

## How it works

`CharacterFactory` receives all three requirements. Weather takes priority, village safety selects friendly or hostile in clear weather, and time selects the character within that factory.

| Weather | Safety | Day | Night | Factory |
| --- | --- | --- | --- | --- |
| Clear | Peaceful | Merchant | Night Watch | Friendly |
| Clear | Threatened | Raider | Infiltrator | Hostile |
| Storm | Either | Rescue Worker | Shelter Keeper | Rescue |

## Play

https://ronno7.github.io/NPCSpawner/


Based on [Gary Woodfine's abstract factory approach](https://dev.to/gary_woodfine/how-to-use-the-abstract-factory-design-pattern-in-c-1gpa).
