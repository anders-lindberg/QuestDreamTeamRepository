using UnityEngine;
using UnityEngine.UI;

public class NPCdialouge : MonoBehaviour
{
    public GameObject dialougePanel;
    public Text dialougeText;
    public string dialouge;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;
    
    
    void Update()
    {
        if)
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
