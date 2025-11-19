using UnityEngine;

public class PickaxePickup : MonoBehaviour
{
    public GameObject replacementPrefab; // Assign in Inspector
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // If the collider is on a child object, get the parent; otherwise use the collider's transform
            Transform collectorTransform = other.transform.parent != null ? other.transform.parent : other.transform;
            Vector3 spawnPosition = collectorTransform.position;
            Quaternion spawnRotation = collectorTransform.rotation;

            Destroy(collectorTransform.gameObject); // Destroy the parent collector

            Instantiate(replacementPrefab, spawnPosition, spawnRotation); // Spawn replacement

            Destroy(gameObject); // Destroy the collectible
        }
    }
}

