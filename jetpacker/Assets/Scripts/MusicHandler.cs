using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    AudioSource[] audioSources;
    ActionKeyHandler actionKeyHandler;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        actionKeyHandler = GetComponent<ActionKeyHandler>();
        audioSources[1].Play();
    }
    void Update()
    {
        if (actionKeyHandler.IsPlayingMusic() && !audioSources[1].isPlaying)
        {
            audioSources[1].Play();
        }
        else if (!actionKeyHandler.IsPlayingMusic() && audioSources[1].isPlaying)
        {
            audioSources[1].Stop();
        }
    }
}
