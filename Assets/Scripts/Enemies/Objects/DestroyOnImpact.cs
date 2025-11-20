using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{
    public string destroyerTag = "Pickaxe";
void OnCollisionEnter2D(Collision2D collision)
    {
        // Log for debugging
        if (collision.gameObject.CompareTag("Pickaxe"))
        {
            Destroy(gameObject);
        }
    }
}
