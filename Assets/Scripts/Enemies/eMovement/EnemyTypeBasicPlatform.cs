using Unity.VisualScripting;
using UnityEngine;

public class EnemyTypeBasicPlatform : MonoBehaviour
{
    public float speed = 2.0f;
    // movement direction: -1 = left, 1 = right
    private float direction = -1f;
    private SpriteRenderer spriteRenderer;
    
    public bool flipSpriteOnTurn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Pickaxe"))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthManager.Instance.ApplyDamage(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }
    void Move()
    {
        // move according to direction
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // When hitting a barrier, set the direction accordingly
        if (other.CompareTag("BarrierLeft"))
        {
            // BarrierLeft should make the enemy go right
            direction = 1f;
            if (flipSpriteOnTurn && spriteRenderer != null)
                spriteRenderer.flipX = false;
        }
        else if (other.CompareTag("BarrierRight"))
        {
            // BarrierRight should make the enemy go left
            direction = -1f;
            if (flipSpriteOnTurn && spriteRenderer != null)
                spriteRenderer.flipX = true;
        }
    }
    
    
}
