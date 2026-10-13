using UnityEngine;

// Centralizes NPC creation so callers only depend on INPC and NPCType.
public class NPCFactory : MonoBehaviour
{
    public INPC GetNPC(NPCType type)
    {
        switch (type)
        {
            case NPCType.Beggar:
                return new Beggar();
            case NPCType.Farmer:
                return new Farmer();
            case NPCType.Shopowner:
                return new Shopowner();
            default:
                return null;
        }
    }
}
