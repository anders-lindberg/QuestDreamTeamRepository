using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{
    public string destroyerTag = "Pickaxe";
    public GameObject particle;
void OnCollisionEnter2D(Collision2D collision)
    {
        // Log for debugging
        if (collision.gameObject.CompareTag("Pickaxe"))
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SoundEffectManager.Play("Bong");
        }
    }
}
