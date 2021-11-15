using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionsSeen = 0;

    public int GetCorrectAnswers()
    {
        return (correctAnswers);
    }
    public int GetQuestionsSeen()
    {
        return (questionsSeen);
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public void IncrementSeenQuestions()
    {
        questionsSeen++;
    }

    public int GetCurrentScore()
    {
        int answer = Mathf.RoundToInt(correctAnswers / (float)questionsSeen * 100);
        Debug.Log(answer);
        return (answer);
    }
}
