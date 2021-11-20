using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float reloadTime = 1.0f;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip successSFX;
    [SerializeField] ParticleSystem setOnFire;

    [SerializeField] ParticleSystem successBeam;
    PlayerMovement playerMovement;
    AudioSource[] audioSources;

    ActionKeyHandler actionKeyHandler;

    bool isTransitioning = false;

    void Start()
    {
        isTransitioning = false;
        playerMovement = GetComponent<PlayerMovement>();
        audioSources = GetComponents<AudioSource>();
        actionKeyHandler = GetComponent<ActionKeyHandler>();
    }

    void Update()
    {
        if (actionKeyHandler.IsLevelChangeInitialized())
        {
            actionKeyHandler.SetLevelChangeInitialized(false);
            LoadNextLevel();
        }
    }

    void LoadLevel(int desiredScene)
    {
        if (desiredScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(desiredScene);
        }
    }

    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene++;
        LoadLevel(currentScene);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        LoadLevel(currentScene);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        setOnFire.Play();
        audioSources[0].Stop();
        audioSources[0].PlayOneShot(crashSFX);
        playerMovement.enabled = false;
        Invoke("ReloadLevel", reloadTime);
    }

    void StartSuccessSequence()
    {

        isTransitioning = true;
        successBeam.Play();
        audioSources[0].PlayOneShot(successSFX);
        playerMovement.enabled = false;
        Invoke("LoadNextLevel", reloadTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || !actionKeyHandler.IsCollisionsEnabled())
            return ;
        if (other.gameObject.tag == "Finish")
            StartSuccessSequence();
        else if (other.gameObject.tag == "Untagged")
            StartCrashSequence();
    }
}
