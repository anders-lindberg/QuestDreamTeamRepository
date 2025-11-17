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
            Vector3 spawnPosition = other.transform.position;
            Quaternion spawnRotation = other.transform.rotation;

            Destroy(other.gameObject); // Destroy the collector

            Instantiate(replacementPrefab, spawnPosition, spawnRotation); // Spawn replacement

            Destroy(gameObject); // Destroy the collectible
        }
    }
}

