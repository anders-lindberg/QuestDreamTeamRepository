using UnityEngine;

public class AttackRock : HurtBoxClass
{
    float timer = 0f;
    GameObject target;
    [SerializeField] float bulletSpeed = 5f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = target.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void DestroySelf()
    {
        
    }
}
