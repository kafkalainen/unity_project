using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float delayTime = 0.5f;
    [SerializeField] ParticleSystem finishEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delayTime);
        }
    }

    private void ReloadScene()
    {
        playerWon = false;
        SceneManager.LoadScene(0);
    }
}
