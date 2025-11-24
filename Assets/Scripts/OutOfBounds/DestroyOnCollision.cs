using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] private PlayerHealthManager healthManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            healthManager.playerIsDead = true;
        }
        else
        {
            Destroy(collision);
        }
    }

}
