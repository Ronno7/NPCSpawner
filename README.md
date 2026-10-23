# NPC Spawner

A small Unity demonstration of the factory pattern, based on the NPC example in Baron's factory chapter.

## Additions

- **Guard** and **Blacksmith** join the original Farmer, Beggar, and Shopowner. Each implements `INPC` and has its own dialogue.
- A plain scene displays labeled capsule figures and their dialogue after pressing **Spawn villagers** or **S**.
- Repeated spawning replaces the previous group instead of accumulating villagers.

The presentation is intentionally minimal so the factory implementation remains the focus. It uses one reusable capsule prefab, one material, and a single button.

## How it works

`Client / Spawn button -> NPCSpawner -> NPCFactory.GetNPC(NPCType) -> INPC`

`NPCFactory` centralizes construction of the concrete NPC classes. `NPCSpawner` requests each type through the factory and calls `Speak()` through the shared interface. It does not construct concrete villagers itself. Invalid enum values are rejected with an exception.

`NPCDemoView` listens for the spawn event and displays a capsule, role label, and dialogue for each returned NPC. The factory creates plain C# objects, as in the chapter; the view handles their visual representation separately. Name and dialogue properties were added to `INPC` to support this display. Dialogue is also logged to the Console.

To add another type, implement `INPC`, add an `NPCType` value, and add a case to `NPCFactory`. The spawner and view iterate over the resulting roster automatically.

## Run

1. Open the `NPCSpawner` folder in Unity **6000.3.24f1**.
2. Open `Assets/Scenes/SampleScene.unity` and enter Play mode.
3. Click **Spawn villagers**, or focus the Game view and press **S**.

The project uses Unity's Input System for keyboard input. A 16:9 Game view is recommended.
