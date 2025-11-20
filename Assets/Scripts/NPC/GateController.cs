using UnityEngine;

public class GateController : MonoBehaviour
{
    public Collider2D gateCollider;        // Collideren for lågen
    public NPCDialogue npcDialogue;        // NPC'en der skal snakkes med først
    public GameObject interactIcon;        // Ikonet E over lågen
    public Animator anim;

    private bool gateUnlocked = false;     // Om lågen kan åbnes
    private bool playerInRange = false;    // Om spilleren er tæt på lågen

    private void Start()
    {
        interactIcon.SetActive(false);     // Ikonet starter skjult
    }

    private void OnEnable()
    {
        npcDialogue.OnFirstDialogueComplete += EnableGateInteraction;
    }

    private void OnDisable()
    {
        npcDialogue.OnFirstDialogueComplete -= EnableGateInteraction;
    }

    private void EnableGateInteraction()
    {
        gateUnlocked = true;               // Spilleren kan nu åbne lågen
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gateUnlocked)
        {
            playerInRange = true;
            interactIcon.SetActive(true);  // Vis E-ikonet
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactIcon.SetActive(false); // Skjul E-ikonet
        }
    }

    private void Update()
    {
        if (playerInRange && gateUnlocked && Input.GetKeyDown(KeyCode.E))
        {
            OpenGate();
        }
    }

    private void OpenGate()
    {
        anim.SetTrigger("Open");            //min lille animation
        gateCollider.enabled = false;       // Lågen forsvinder
        interactIcon.SetActive(false);      // Fjern E-ikonet
        gateUnlocked = false;          // Forhindrer gentagen åbning :D
        Debug.Log("Lågen er åben!");
    }
}
