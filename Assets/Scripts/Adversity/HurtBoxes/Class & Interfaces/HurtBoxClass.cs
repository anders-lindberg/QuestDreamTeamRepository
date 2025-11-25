using System.Collections.Generic;
using UnityEngine;

public class HurtBoxClass : MonoBehaviour
{
    [SerializeField] protected int damageAmount = 1;
    [SerializeField] protected float lifeSpan = 0.2f;
    [SerializeField] protected string sourceTag;
    [SerializeField] protected bool isDestructable = true;
    private HashSet<GameObject> alreadyHit = new HashSet<GameObject>();
    [SerializeField] GameObject vfx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        GameObject targetRoot = other.transform.root.gameObject;
        if (alreadyHit.Contains(targetRoot))
        {
            return;
        }

        IDamageable hp = other.GetComponent<IDamageable>();
        if (hp == null)
        {
            hp = other.GetComponentInParent<IDamageable>();
        }
        if (hp == null)
        {
            hp = other.GetComponentInChildren<IDamageable>();
        }
        if (hp != null && !other.CompareTag(sourceTag))
        {
            hp.TakeDamage(damageAmount);
            alreadyHit.Add(targetRoot);

            if (isDestructable)
            {
                if(vfx != null)
                {
                    Instantiate(vfx, transform.position, Quaternion.identity);
                }
                
                Destroy(gameObject);
            }
        }
        DestroySelf();
    }
    protected virtual void DestroySelf()
    {
        Destroy(gameObject, lifeSpan);
    }
}
