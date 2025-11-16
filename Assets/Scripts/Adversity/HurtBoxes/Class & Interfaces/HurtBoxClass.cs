using UnityEngine;

public class HurtBoxClass : MonoBehaviour
{
    [SerializeField] protected int damageAmount = 1;
    [SerializeField] protected float lifeSpan = 0.2f;
    [SerializeField] protected string sourceTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(sourceTag))
        {
            IDamageable hp = other.GetComponent<IDamageable>();
            if(hp != null)
            {
                hp.TakeDamage(damageAmount);
            }
        }
    }
}
