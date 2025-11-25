using UnityEngine;

public class HubSpawnLocation : MonoBehaviour
{
    [SerializeField] GameObject pickPrefab;
    //H�ndterer player spawn logik - og loader ikke selve hub-scenen
    [SerializeField] private string entranceID;
   

    private void Start()
    {
        if(LevelManager.Instance.lastHubEntranceID == entranceID)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if(player != null)
            {
                player.transform.position = transform.position;
            }

            
        }
    }
}
