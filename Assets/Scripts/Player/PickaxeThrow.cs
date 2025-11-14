using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PickaxeThrow : MonoBehaviour
{
    [Header("Launch settings")]
    public float speed = 10f;
    public float launchAngle = 70f;

    [Header("Gravity settings")]
    [Tooltip("Initial gravity scale (set on the Rigidbody2D)")]
    public float initialGravityScale = 1f;
    [Tooltip("Increased gravity scale after delay")]
    public float increasedGravityScale = 3f;
    [Tooltip("Time (seconds) before gravity increases")]
    public float gravityIncreaseDelay = 1f;

    private Rigidbody2D rb;
    private float originalGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();

        // Store original gravity and set initial
        originalGravityScale = rb.gravityScale;
        rb.gravityScale = initialGravityScale;

        // Launch immediately
        LaunchAtAngle(launchAngle, speed);

        // Start the gravity increase coroutine
        StartCoroutine(IncreaseGravityAfterDelay(gravityIncreaseDelay));
    }
    
        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject); 
    
    }  
        
           
        
    
    /// <summary>
    /// Increases gravity scale after a specified delay.
    /// </summary>
    private IEnumerator IncreaseGravityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (rb != null)
        {
            rb.gravityScale = increasedGravityScale;
        }
    }

    public void Launch()
    {
        Vector2 forward = transform.right;
        rb.linearVelocity = forward.normalized * speed;
    }

    public void LaunchAtAngle(float angleDegrees, float speed)
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        Vector2 forward = transform.right;
        Vector2 launchDir = Quaternion.Euler(0f, 0f, angleDegrees) * forward;

        rb.linearVelocity = launchDir.normalized * speed;
    }
}
