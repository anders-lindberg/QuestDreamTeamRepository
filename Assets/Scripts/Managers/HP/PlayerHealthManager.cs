using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager Instance;
    [Header("Ikke rør ved maxHP og currentHp")]
    public int maxHp = 5;
    public int currentHp;
    public bool playerIsDead = false;
    [SerializeField] private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        currentHp = maxHp;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ApplyDamage(int amount)
    {
        currentHp -= amount;
        SoundEffectManager.Play("Damage");
        Debug.Log("playerHealthmanager hp is"+ currentHp);
        if(currentHp <= 0 )
        {
            currentHp = 0;
            Debug.Log("playerHealthmanager has died");
            playerIsDead = true;
        }
    }
    public void Heal(int amount)
    {
        currentHp = Mathf.Min(currentHp + amount, maxHp);
        Debug.Log($"Player has healed, hp is now {currentHp}");
    }

    public void HealMax()
    {
        currentHp = maxHp;
        Debug.Log(currentHp);
    }
}
