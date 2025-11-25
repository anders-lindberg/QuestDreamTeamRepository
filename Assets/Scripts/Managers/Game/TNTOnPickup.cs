using UnityEngine;

public class TNTOnPickup : MonoBehaviour
{
    [SerializeField] private int tntIndex;

    private void Start()
    {
        if (GameManager.Instance == null) return;

        //checks if the playerHealthmanager has already picked up the tnt part in the scene. If this is the case, it destroys the tnt part in the scene
        if(tntIndex == 1 && GameManager.Instance.level1TNT || tntIndex == 2 && GameManager.Instance.level2TNT || tntIndex == 3 && GameManager.Instance.level3TNT)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.TNTCollected(tntIndex);
            Destroy(gameObject);
        }
    }
}
