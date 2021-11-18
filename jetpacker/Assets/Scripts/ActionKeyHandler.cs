using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionKeyHandler : MonoBehaviour
{
    bool    isPlayingMusic = true;
    bool    collisionsEnabled = true;
    bool    initiateLevelChange = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionsEnabled = !collisionsEnabled;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            initiateLevelChange = !initiateLevelChange;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            isPlayingMusic = !isPlayingMusic;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public bool IsPlayingMusic()
    {
        return (isPlayingMusic);
    }

    public bool IsCollisionsEnabled()
    {
        return (collisionsEnabled);
    }

    public bool IsLevelChangeInitialized()
    {
        return (initiateLevelChange);
    }

    public void SetLevelChangeInitialized(bool state)
    {
        initiateLevelChange = state;
    }

}
