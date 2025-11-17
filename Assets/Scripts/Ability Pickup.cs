using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public class Collectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add the SpeedBoost script to the player
            if (other.GetComponent<PickaxeThrow>() == null)
            {
                other.gameObject.AddComponent<PickaxeThrow>();
            }

            Destroy(gameObject); // Remove the collectible
        }
    }
}
}
