using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class NPCDialogue : MonoBehaviour

{
    int collected = GameManager.Instance.tNTCollected;

    public event Action OnFirstDialogueComplete;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public GameObject interactIcon;

    public string[] firstTimelines;
    public string[] repeatLines;

    public string[] oneItemLines;
    public string[] twoItemLines;
    public string[] threeItemLines;

    public float typingSpeed = 0.02f;   // Hastighed hvis du vil have typing-effect (kan sættes til 0 for ingen)
    
    private bool playerInRange = false;
    private bool hasTalked = false;
    private bool dialogueActive = false;

    private int currentIndex = 0;
    private string[] currentLines;
    private Coroutine typingCoroutine;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactIcon.SetActive(false);
            EndDialogue();
        }
    }


    private void Update()
    {
        if (!playerInRange) return;

        // Start eller fortsæt dialog når man trykker E
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueActive)
                StartDialogue();
            else
                NextLine();
        }
    }

    private void StartDialogue()
    {
        dialogueActive = true;
        dialoguePanel.SetActive(true);

        interactIcon.SetActive(false);

        collected = GameManager.Instance.tNTCollected;

        if (collected <= 0)
        {
            Debug.Log(collected);
            currentLines = hasTalked ? repeatLines : firstTimelines;
            currentIndex = 0;
            ShowLine();
        }
        else if (collected > 0) 
        {
            Debug.Log(collected);
            switch (collected)
            {
                case 1: currentLines = hasTalked ? repeatLines : oneItemLines; break;
                case 2: currentLines = hasTalked ? repeatLines : twoItemLines; break;
                case 3: currentLines = hasTalked ? repeatLines : threeItemLines; break;
            }

            currentIndex = 0;
            ShowLine();
        }
    }

    private void ShowLine()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine(currentLines[currentIndex]));
    }

    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            if (typingSpeed > 0)
                yield return new WaitForSeconds(typingSpeed);
            else
                yield return null;
        }
    }

    private void NextLine()
    {
        // Hvis typing er i gang → skip til fuld linje
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = currentLines[currentIndex];
            typingCoroutine = null;
            return;
        }

        currentIndex++;

        if (currentIndex >= currentLines.Length)
        {
            EndDialogue();
            if (!hasTalked)
            {
                OnFirstDialogueComplete?.Invoke();
            }
            hasTalked = true;
            return;
        }

        ShowLine();
    }

    private void EndDialogue()
    {
        dialogueActive = false;
        dialoguePanel.SetActive(false);
        if(playerInRange) interactIcon.SetActive(true);

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = null;
    }
}