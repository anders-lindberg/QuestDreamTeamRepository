using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(100);
        }
    }
}
