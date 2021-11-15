using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30.0f;
    [SerializeField] float timeToShowCorrectAnswer = 10.0f;
    float timerValue;
    public bool isAnsweringQuestion;
    public bool loadNextQuestion;
    public float fillFraction;
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        // Debug.Log("Time is: " + timerValue);
        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = Mathf.Clamp(timerValue / timeToCompleteQuestion, 0.0f, 1.0f);
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = fillFraction = Mathf.Clamp(timerValue / timeToShowCorrectAnswer, 0.0f, 1.0f);
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
