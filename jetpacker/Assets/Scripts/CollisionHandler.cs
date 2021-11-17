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
    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        isTransitioning = false;
        playerMovement = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
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
        isTransitioning = true;
        setOnFire.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        playerMovement.enabled = false;
        Invoke("ReloadLevel", reloadTime);
    }

    void StartSuccessSequence()
    {

        isTransitioning = true;
        successBeam.Play();
        audioSource.PlayOneShot(successSFX);
        playerMovement.enabled = false;
        Invoke("LoadNextLevel", reloadTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
            return ;
        if (other.gameObject.tag == "Friendly")
            Debug.Log("Friendly!");
        else if (other.gameObject.tag == "Finish")
            StartSuccessSequence();
        else if (other.gameObject.tag == "Untagged")
            StartCrashSequence();
    }
}
