using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Text sfxText;
    [SerializeField] TMP_Text ambienceText;
    [SerializeField] TMP_Text masterText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(float volume)
    {
        Debug.Log("Work");
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        masterText.text = volumeToInt.ToString();
        audioMixer.SetFloat("MasterVolume", MathF.Log10(volume) * 20);

    }
    public void SetSFXVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        sfxText.text = volumeToInt.ToString();
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    public void SetAmbienceVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        ambienceText.text = volumeToInt.ToString();
        audioMixer.SetFloat("AmbienceVolume", Mathf.Log10(volume) * 20);
    }
}
