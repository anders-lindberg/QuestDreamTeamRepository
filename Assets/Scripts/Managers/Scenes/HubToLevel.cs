using UnityEngine;

public class HubToLevel : MonoBehaviour
{
    //Loader en specifik scene - og fortæller samtidig levelManager'en hvilken entrance spilleren er gået indad
    //(bruges senere til player-spawn ved return to hub)
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string entranceID;  // Unique ID for this entrance

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelManager.Instance.lastHubEntranceID = entranceID;
            LevelManager.Instance.StartLoadScene(sceneToLoad);
        }
    }
}
