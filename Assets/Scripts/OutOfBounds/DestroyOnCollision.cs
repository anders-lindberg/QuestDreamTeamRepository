using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] private PlayerHealthManager player;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        player = PlayerHealthManager.Instance;

        if (collider.gameObject.CompareTag("Player"))
        {
            player.ApplyDamage(100);
        }
    }
}
