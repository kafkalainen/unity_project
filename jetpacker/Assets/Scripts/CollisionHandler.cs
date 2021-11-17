using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] float reloadTime = 1.0f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
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
        playerMovement.enabled = false;
        Invoke("ReloadLevel", reloadTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Friendly")
            Debug.Log("Friendly!");
        else if (other.gameObject.tag == "Finish")
            LoadNextLevel();
        else if (other.gameObject.tag == "Untagged")
            StartCrashSequence();
    }
}
