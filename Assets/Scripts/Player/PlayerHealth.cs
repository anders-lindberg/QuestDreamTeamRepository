using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int maxHp = 5;
    int currentHp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }
    public void TakeDamage(int amount)
    {
        currentHp -= amount;//currentHp = currentHp - amount(den mængde skade jeg lige modtog)
        Debug.Log("player took damage, HP is now" + currentHp);
        if(currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
