using UnityEngine;

[RequireComponent(typeof(NPCFactory))]
public class NPCSpawner : MonoBehaviour
{
    public NPCFactory m_Factory;

    private INPC m_Farmer;
    private INPC m_Beggar;
    private INPC m_Shopowner;

    private void Awake()
    {
        if (m_Factory == null)
            m_Factory = GetComponent<NPCFactory>();
    }

    [ContextMenu("Spawn Villagers")]
    public void SpawnVillagers()
    {
        if (m_Factory == null)
        {
            Debug.LogError("Assign an NPCFactory to the NPCSpawner.", this);
            return;
        }

        // These are plain C# objects, as in the book's example.
        m_Beggar = m_Factory.GetNPC(NPCType.Beggar);
        m_Farmer = m_Factory.GetNPC(NPCType.Farmer);
        m_Shopowner = m_Factory.GetNPC(NPCType.Shopowner);

        m_Beggar.Speak();
        m_Farmer.Speak();
        m_Shopowner.Speak();
    }
}
