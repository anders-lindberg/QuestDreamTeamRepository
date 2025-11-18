using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager Instance;
    public int maxHp = 5;
    public int currentHp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awaker()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        currentHp = maxHp;
    }

    public void ApplyDamage(int amount)
    {
        currentHp -= amount;
        if(currentHp <= 0)
        {
            Debug.Log("player has died");
        }
    }
    public void Heal(int amount)
    {
        currentHp = Mathf.Min(currentHp + amount, maxHp);
    }
}
