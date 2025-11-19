using UnityEngine;

public class PlayManHealth : MonoBehaviour, IDamageable
{
    public void TakeDamage(int amount)
    {
        PlayerHealthManager.Instance.ApplyDamage(amount);
    }
    public int GetCurrentHealth()
    {
        return PlayerHealthManager.Instance.currentHp;
    }
}
