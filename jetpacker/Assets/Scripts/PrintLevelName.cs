using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PrintLevelName : MonoBehaviour
{
    [SerializeField] TextMeshPro field;
    void Start()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        string levelName = SceneManager.GetActiveScene().name;
        field.text = "Level " + levelIndex + ": \n" + levelName;
    }
}
