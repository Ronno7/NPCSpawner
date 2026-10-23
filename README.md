# Abstract Factory NPC Spawner

Requirements based Unity spawn demo following [Gary Woodfine's approach](https://dev.to/gary_woodfine/how-to-use-the-abstract-factory-design-pattern-in-c-1gpa).

## Play

Open the [WebGL build]([abstract-factory-demo/index.html](https://ronno7.github.io/NPCSpawner/)). Choose **Day / Night** and **Peaceful / Threatened**, then press **Spawn**.

| Village safety | Time | Factory | Character |
| --- | --- | --- | --- |
| Peaceful | Day | FriendlyCharacterFactory | Merchant |
| Peaceful | Night | FriendlyCharacterFactory | Night Watch |
| Threatened | Day | HostileCharacterFactory | Raider |
| Threatened | Night | HostileCharacterFactory | Infiltrator |

## How it works

`CharacterFactory` receives `SpawnRequirements` and selects one of two concrete factories based on village safety. That factory uses time of day to create an `INPC`. The scene instantiates a capsule for the result, with a muted group colour, name, and dialogue. Each spawn replaces the previous character.

## Project

Unity **6000.3.24f1**. Scene: `NPCSpawner/Assets/Scenes/AbstractFactoryDemo.unity`. Scripts: `NPCSpawner/Assets/Scripts/AbstractFactory`.

Reference: [Woodfine's sample repository](https://github.com/garywoodfine/software-design-patterns). This demo follows the article's refactored requirements-driven factory structure.
