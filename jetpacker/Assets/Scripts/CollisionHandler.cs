using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    PlayerMovement playerMovement;
    AudioSource audioSource;
    ParticleSystem setOnFire;
    [SerializeField] float reloadTime = 1.0f;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip successSFX;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
        setOnFire = FindObjectOfType<ParticleSystem>();
    }

    void LoadLevel(int desiredScene)
    {
        Debug.Log("Before boolean: " + desiredScene);
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        if (desiredScene < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log(desiredScene);
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
        Debug.Log(currentScene);
        LoadLevel(currentScene);
    }

    void StartCrashSequence()
    {
        setOnFire.Play();
        audioSource.PlayOneShot(crashSFX);
        playerMovement.enabled = false;
        Invoke("ReloadLevel", reloadTime);
    }

    void StartSuccessSequence()
    {
        audioSource.PlayOneShot(crashSFX);
        playerMovement.enabled = false;
        Invoke("LoadNextLevel", reloadTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Friendly")
            Debug.Log("Friendly!");
        else if (other.gameObject.tag == "Finish")
            StartSuccessSequence();
        else if (other.gameObject.tag == "Untagged")
            StartCrashSequence();
    }
}
