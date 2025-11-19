using UnityEngine;


public class EnemyTypeBasic : MonoBehaviour
{
    public float speed = 2.0f;
    public float moveleftTime = 3.0f;
    public float moverightTime = 3.0f;
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
                spriteRenderer.flipX = true;
            }
            else
            {
                    spriteRenderer.flipX = false;
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
        }
    }
    
}
