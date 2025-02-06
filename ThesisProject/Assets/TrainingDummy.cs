using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Hello! I am a training dummy and I hate you!");
    }
}
