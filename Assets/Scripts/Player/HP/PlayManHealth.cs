using UnityEngine;

public class PlayManHealth : MonoBehaviour, IDamageable
{
    public void TakeDamage(int amount)
    {
        Debug.Log($"Playmanhealth.takedamge called with{amount}");
        PlayerHealthManager.Instance.ApplyDamage(amount);
    }
    public int GetCurrentHealth()
    {
        return PlayerHealthManager.Instance.currentHp;
    }
}
