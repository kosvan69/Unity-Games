﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] musicArray;
    private AudioSource audioSource;

    void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Due to OnLevelWasLoaded executing first need to move this init
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = musicArray[level];

        if (thisLevelMusic)
        {
            if (audioSource)
            {
                audioSource.clip = thisLevelMusic;
                audioSource.loop = true;
                audioSource.Play();
                audioSource.volume = PlayerPrefsManager.GetMasterVolume();
            }
            else
            {
                Debug.Log("dwadwada");
            }
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
