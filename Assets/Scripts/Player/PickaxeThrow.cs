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
    public Transform PlayerTransform;

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

        // Start the gravity increase coroutine
        StartCoroutine(IncreaseGravityAfterDelay(gravityIncreaseDelay));
    }
    
        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject); 
    
    }

    void Update()
    {
        
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
        LaunchWithDirection(angleDegrees, speed, 1f); // default: launch to the right
    }

    /// <summary>
    /// Launch at an angle with a direction multiplier. Use directionMultiplier = -1 for left, 1 for right.
    /// </summary>
    public void LaunchWithDirection(float angleDegrees, float speed, float directionMultiplier = 1f)
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        // Flip the angle if throwing left
        float effectiveAngle = angleDegrees * directionMultiplier;
        Vector2 forward = transform.right * directionMultiplier;
        Vector2 launchDir = Quaternion.Euler(0f, 0f, effectiveAngle) * forward;

        rb.linearVelocity = launchDir.normalized * speed;
    }


}
