using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCFactory))]
public class NPCSpawner : MonoBehaviour
{
    public NPCFactory m_Factory;
    private readonly List<INPC> villagers = new List<INPC>();
    public IReadOnlyList<INPC> Villagers => villagers;
    public event Action VillagersSpawned;

    private void Awake()
    {
        if (m_Factory == null) m_Factory = GetComponent<NPCFactory>();
    }

    [ContextMenu("Spawn Villagers")]
    public void SpawnVillagers()
    {
        if (m_Factory == null) m_Factory = GetComponent<NPCFactory>();
        if (m_Factory == null)
        {
            Debug.LogError("Assign an NPCFactory to the NPCSpawner.", this);
            return;
        }
        // Replace the roster instead of accumulating objects on every key press.
        villagers.Clear();
        foreach (NPCType type in Enum.GetValues(typeof(NPCType)))
        {
            INPC villager = m_Factory.GetNPC(type);
            villagers.Add(villager);
            villager.Speak();
        }
        VillagersSpawned?.Invoke();
    }
}
