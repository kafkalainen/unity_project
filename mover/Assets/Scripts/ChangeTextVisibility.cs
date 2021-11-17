using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeTextVisibility : MonoBehaviour
{
    Timer timer;
    OnCollision collisionDetector;
    Scorer scorer;

    float time;

    [Header("Text objects")]
    [SerializeField] TextMeshProUGUI welcomeText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeElapsed;
    void Awake()
    {
        welcomeText.enabled = true;
        scoreText.enabled = true;
        timer = FindObjectOfType<Timer>();
        collisionDetector = FindObjectOfType<OnCollision>();
        scorer = FindObjectOfType<Scorer>();
    }

    private bool SetTextVisibility(float t, bool state)
    {
        if (state && t <= 0.0f)
        {
            timer.SetTime(5.0f);
            return (true);
        }
        return (false);
    }

    void Update()
    {
        timeElapsed.text = "Time: " + Time.time;
        if (!timer.setVisibility)
        {
            welcomeText.enabled = false;
        }
        scoreText.text =  "Score: " + scorer.GetScore();
    }
}
