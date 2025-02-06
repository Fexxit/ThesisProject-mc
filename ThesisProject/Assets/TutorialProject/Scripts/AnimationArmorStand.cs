using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationArmorStand : MonoBehaviour, IInteractable
{
    public void Interact()
    {

        if (GetComponent<Animation>().isPlaying)
        {
            return;
        }
        else
        {
            GetComponent<Animation>().Play();
        }
    }
}
