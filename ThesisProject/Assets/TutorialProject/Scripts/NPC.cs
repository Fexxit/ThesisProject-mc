using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] SO_Dialogue dialogue;

    public void Interact()
    {
        DialogueManager.Instance.QueueDialogue(dialogue);
    }
}
