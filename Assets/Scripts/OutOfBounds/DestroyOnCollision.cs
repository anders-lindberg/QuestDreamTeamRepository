using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] private PlayerHealthManager player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = PlayerHealthManager.Instance;
        if (collision.gameObject.CompareTag("Player"))
        {
            player.ApplyDamage(100);
        }
    }
}
