using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    int maxHp = 5;
    int currentHp;
    public bool isDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
        isDead = false;
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;//currentHp = currentHp - amount(den mængde skade jeg lige modtog)
        Debug.Log("player took damage, HP is now" + currentHp);
        if(currentHp <= 0)
        {
            gameObject.SetActive(false);
            isDead = true;

        }
    }
}
