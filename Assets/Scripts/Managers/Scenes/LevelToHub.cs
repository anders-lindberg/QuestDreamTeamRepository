using UnityEngine;

public class LevelToHub : MonoBehaviour
{
    //Loader selve hub-scenen - UDEN at tage sig af spawn-logikken
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelManager.Instance.ReturnToHub();
        }
    }
}
