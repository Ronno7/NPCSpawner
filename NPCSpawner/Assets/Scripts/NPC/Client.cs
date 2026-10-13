using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NPCSpawner))]
public class Client : MonoBehaviour
{
    public NPCSpawner m_SpawnerNPC;

    private void Awake()
    {
        if (m_SpawnerNPC == null)
            m_SpawnerNPC = GetComponent<NPCSpawner>();
    }

    private void Update()
    {
        // Unity 6 project uses the Input System instead of legacy Input.
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null && keyboard.sKey.wasPressedThisFrame)
        {
            if (m_SpawnerNPC == null)
            {
                Debug.LogError("Assign an NPCSpawner to the Client.", this);
                return;
            }

            m_SpawnerNPC.SpawnVillagers();
        }
    }
}
