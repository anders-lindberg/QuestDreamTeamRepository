using UnityEngine;

public class HurtBoxClass : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float lifeSpan = 0.2f;
    [SerializeField] private string sourceTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth hp = other.GetComponent<PlayerHealth>();
            if(hp != null)
            {
                hp.TakeDamage(damageAmount);
            }
        }
    }
}
