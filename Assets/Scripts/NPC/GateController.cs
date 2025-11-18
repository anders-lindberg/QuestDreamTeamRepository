using UnityEngine;

public class GateController : MonoBehaviour
{
    public Collider2D gateCollider;
    public NPCDialogue npcDialogue;

    private void OnEnable()
    {
        npcDialogue.OnFirstDialogueComplete += UnlockGate;
    }

    private void OnDisable()
    {
        npcDialogue.OnFirstDialogueComplete -= UnlockGate;
    }

    private void UnlockGate()
    {
        if (gateCollider != null)
        {
            gateCollider.enabled = false; 
            Debug.Log("låge åben");    
        }
    }
    
}
