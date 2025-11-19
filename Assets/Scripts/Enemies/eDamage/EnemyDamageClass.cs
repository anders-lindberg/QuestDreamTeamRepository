using UnityEngine;

public class EnemyDamageClass : MonoBehaviour
{
  [SerializeField] protected int damageAmount = 1;

  protected virtual void ApplyDamage(GameObject target)
    {
        if (target.CompareTag("Player"))
        {
            IDamageable hp = target.GetComponent<IDamageable>();
            if(hp != null)
            {
                hp.TakeDamage(damageAmount);
                Debug.Log($"{name} dealt {damageAmount} damage to {target.name}");
            }
        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyDamage(collision.gameObject);
    }
}
