using UnityEngine;

public class Stalakit : MonoBehaviour
{
    private Rigidbody2D stalRb;
    [SerializeField] private GameObject hurtBox;
    [SerializeField] private GameObject breakVFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stalRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            stalRb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

       if(hurtBox != null)
        {
            Instantiate(hurtBox, transform.position, Quaternion.identity);
        }
        if(breakVFX != null)
        {
            Instantiate(breakVFX, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
