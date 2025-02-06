using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private bool inDialogue;
    private bool isTyping;

    Queue<SO_Dialogue.Info> dialogueQueue;
    private string completeText;
    [SerializeField]private float textDelay = 0.1f;

    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text dialogueText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        dialogueQueue = new Queue<SO_Dialogue.Info>();
    }

    public IEnumerator TypeText(SO_Dialogue.Info info)
    {
        isTyping = true;

        foreach (char c in info.dialogue.ToCharArray())
        {
            yield return new WaitForSeconds(textDelay);
            dialogueText.text += c;
        }

        isTyping = false;
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    private void OnInteract(InputValue input)
    {
        if (inDialogue)
        {
            DequeueDialogue();
        }
    }

    public void QueueDialogue(SO_Dialogue dialogue)
    {
        if (inDialogue)
        {
            return;
        }

        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        
        inDialogue = true;

        dialogueBox.SetActive (true);
        dialogueQueue.Clear();

        foreach(SO_Dialogue.Info line in dialogue.dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (isTyping)
        {
            CompleteText();
            StopAllCoroutines();
            isTyping = false;
            return;
        }

        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        SO_Dialogue.Info info = dialogueQueue.Dequeue();
        completeText = info.dialogue;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }

}
