# NPC Spawner

Small Unity demonstration of factory pattern, based on the NPC example in Baron's factory chapter.

## Additions

- **Guard** and **Blacksmith** join the original Farmer, Beggar, and Shopowner. Each implements `INPC` and has a short line explaining its role.
- A plain scene displays labeled capsule figures and their dialogue after pressing **Spawn villagers** or **S**. The figures appear one at a time, 0.3 seconds apart.
- Muted colours distinguish the roles: sage for Farmer, taupe for Beggar, ochre for Shopowner, slate blue for Guard, and clay for Blacksmith.
- Repeated spawning cancels any unfinished reveal and starts a fresh group instead of accumulating villagers.

## How it works

`NPCSpawner` requests villagers from `NPCFactory`, which creates each type through the shared `INPC` interface. `NPCDemoView` displays them one at a time with labels and dialogue.

## Play

Open the web build and click **Spawn villagers** or press **S**.
