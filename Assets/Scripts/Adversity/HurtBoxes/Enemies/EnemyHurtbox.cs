using UnityEngine;

public class EnemyHurtbox : HurtBoxClass
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    protected override void OnTriggerEnter2D(Collider2D other)
        {
            // Here you can add logic to damage the playerHealthmanager
             // Destroy the hurtbox after hitting the playerHealthmanager
             GameObject root = other.transform.root.gameObject;

             IDamageable hp = root.GetComponent<IDamageable>();
             if (hp != null && !other.CompareTag(sourceTag))
             {
                 hp.TakeDamage(damageAmount);
                 Debug.Log("Player hit by Enemy Hurtbox");
             }
             else
            {
                Debug.Log($"No IDamageable found on {other.name}.");
            }
        }
    
    
}
