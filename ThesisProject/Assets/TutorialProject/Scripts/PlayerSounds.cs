using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMovement(InputValue input)
    {
        if (audioSource.clip != SoundBank.instance.stepAudio)
        {
            audioSource.clip = SoundBank.instance.stepAudio;
            audioSource.loop = true;
        }
        
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void OnMovementStop(InputValue input)
    {
        audioSource.Stop();
    }
}
