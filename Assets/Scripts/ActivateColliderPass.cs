using UnityEngine;

public class ActivateColliderPass : MonoBehaviour
{
    public Collider2D colliderToTrigger; // collider der skal aktiveres
    public Collider2D colliderToEnable;
    public string playerTag = "Player";

    private void Start()
    {
        colliderToEnable.enabled = false;
        colliderToTrigger.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            colliderToEnable.enabled = true;  // tænd box collideren
        }
    }
}
