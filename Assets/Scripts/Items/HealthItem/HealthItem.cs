using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthManager.Instance.Heal(2);
        }
        if(destroyVFX != null)
        {
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
