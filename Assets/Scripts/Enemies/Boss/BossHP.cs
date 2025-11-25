using UnityEngine;

public class BossHP : MonoBehaviour, IDamageable
{
    [SerializeField] int maxbossHp = 25;
    [SerializeField] GameObject bossDeathVFX;
    
    int currentHp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxbossHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        Debug.Log($"boss took damage, hp = {currentHp}");
        currentHp -= amount;
        if (currentHp <= 0)
        {
            currentHp = 0;
            if(bossDeathVFX != null)
            {
                Instantiate(bossDeathVFX, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
