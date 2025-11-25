using UnityEngine;

public class ActivateColliderPass : MonoBehaviour
{
    public Collider2D colliderToEnable; // collider der skal aktiveres
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            colliderToEnable.enabled = true;  // tænd collideren
            this.gameObject.SetActive(false); // slå triggeren fra efter player går forbi
        }
    }
}
