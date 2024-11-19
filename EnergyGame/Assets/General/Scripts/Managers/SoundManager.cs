using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceSFX;
    [SerializeField] private AudioSource audioSourceBG;


    [Header("Volume")]
    [SerializeField] private float musicVolume;
    [SerializeField] private float sfxVolume;

    [Header("SFX Clips")]
    public AudioClip interaction;
    public AudioClip buy;
    public AudioClip rotatePipes;
    
    [Header("BG Clips")] 
    public AudioClip backgroundGame;
    public AudioClip backgroundMinigame;

    private void Awake()
    {
        audioSourceBG.volume = musicVolume;
        audioSourceSFX.volume = sfxVolume;
    }

    public void PlaySFXClip(AudioClip clip)
    {
        audioSourceSFX.PlayOneShot(clip);
    }

    public void PlayBGCLip(bool isActive, AudioClip clip)
    {
        if (isActive)
        {
            audioSourceBG.clip = clip;
            audioSourceBG.Play();
        }
        else
        {
            audioSourceBG.Pause();
            audioSourceBG.clip = null;
        }
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }
    
}
