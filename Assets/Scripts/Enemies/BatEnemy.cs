using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    public GameObject HurtBox;
    [Header("Movement")]
    public float speed = 2f;
    
    [Header("Wait times")]
    public float minWaitTime = 1f;
    public float maxWaitTime = 3f;
    
    [Header("Waypoints")]
    public Transform batPoint1;
    public Transform batPoint2;
    public Transform batPoint3;
    
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private float waitTimer = 0f;
    private bool isWaiting = false;
    private float currentWaitDuration = 0f;
    
    void Start()
    {
        // Initialize waypoint array
        waypoints = new Transform[] { batPoint1, batPoint2, batPoint3 };
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No bat waypoints assigned!");
            return;
        }
        
        // Start at first waypoint and begin waiting
        currentWaypointIndex = 0;
        StartWaitingAtCurrentPoint();
    }

    void Update()
    {
        if (waypoints.Length == 0) return;
        
        Transform targetPoint = waypoints[currentWaypointIndex];
        
        if (isWaiting)
        {
            // Count down wait timer
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                Debug.Log($"Bat finished waiting at waypoint {currentWaypointIndex + 1}. Moving to next.");
            }
        }
        else
        {
            // Move towards current waypoint
            transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
            
            // Check if reached waypoint
            if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                // Move to next waypoint and start waiting
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                StartWaitingAtCurrentPoint();
            }
        }
    }
    
    /// <summary>
    /// Start waiting at the current waypoint for a random duration.
    /// </summary>
    private void StartWaitingAtCurrentPoint()
    {
        currentWaitDuration = Random.Range(minWaitTime, maxWaitTime);
        waitTimer = currentWaitDuration;
        isWaiting = true;
        Debug.Log($"Bat arrived at waypoint {currentWaypointIndex + 1}. Waiting for {currentWaitDuration:F2} seconds.");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Log for debugging
        if (collision.gameObject.CompareTag("Pickaxe"))
        {
            Destroy(gameObject);
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
