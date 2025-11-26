using UnityEngine;


public class EnemyTypeBasic : MonoBehaviour
{
    public float speed = 2.0f;
    public float moveleftTime = 3.0f;
    public float moverightTime = 3.0f;
    public GameObject HurtBox;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveleftTime -= Time.deltaTime;
        if (moveleftTime > 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
        moverightTime -= Time.deltaTime;
            if (moverightTime > 0)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                spriteRenderer.flipX = false;
            }
            else
            {
                    spriteRenderer.flipX = true;
                moveleftTime = 3.0f;
                moverightTime = 3.0f;
            }
        }
        
    }
    // Correct Unity callback for non-trigger 2D collisions
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Log for debugging
        if (collision.gameObject.CompareTag("Pickaxe"))
        {
            Destroy(gameObject);
            SoundEffectManager.Play("Destroy");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Collider2D otherCollider = collision.collider;
            Collider2D thisCollider = GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(thisCollider, otherCollider);
            Instantiate(HurtBox, transform.position, Quaternion.identity);
        }

    }
     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthManager.Instance.ApplyDamage(1);
        }
    }
    
    }

    

