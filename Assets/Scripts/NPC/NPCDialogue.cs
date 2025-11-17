using UnityEngine;
using TMPro;
using System.Collections;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public string[] lines;
    public float lineDelay = 2f;

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            StartCoroutine(StartDialogue());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            StopAllCoroutines();
            dialogueBox.SetActive(false);
        }
    }

    private IEnumerator StartDialogue()
    {
        dialogueBox.SetActive(true);
        foreach (string line in lines)
        {
            dialogueText.text = line;
            yield return new WaitForSeconds(lineDelay);
        }
        dialogueBox.SetActive(false);
    
    }
}
