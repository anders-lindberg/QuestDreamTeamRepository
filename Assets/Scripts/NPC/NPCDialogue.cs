using UnityEngine;
using TMPro;
using System.Collections;

public class NPCDialogue : MonoBehaviour

{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] firstTimelines;
    public string[] repeatLines;

    public float lineDelay;

    private bool playerInRange = false;
    private bool hasTalked = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playerInRange)
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
            dialoguePanel.SetActive(false);
        }
    }

    private IEnumerator StartDialogue()
    {
        dialoguePanel.SetActive(true);
        string[] currentLines = hasTalked ? repeatLines : firstTimelines;
        foreach (string line in currentLines)
        {
            dialogueText.text = line;
            yield return new WaitForSeconds(lineDelay);
        }
        dialoguePanel.SetActive(false);
        hasTalked = true;
    }  
}