using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    void LoadLevel(int desiredScene)
    {
        if (SceneManager.sceneCountInBuildSettings < desiredScene + 1)
            SceneManager.LoadScene(desiredScene);
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
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Friendly")
            Debug.Log("Friendly!");
        else if (other.gameObject.tag == "Finish")
            LoadNextLevel();
        else if (other.gameObject.tag == "Untagged")
            ReloadLevel();
    }
}
