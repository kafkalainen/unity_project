using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;

[CreateAssetMenu(fileName = "newQuestion", menuName = "QuizQuestion", order = 0)]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] private string question = "Enter new question text here";
    [SerializeField] private string[] answers = new string[4];
    [SerializeField] private int rightAnswerIndex;

    public string GetQuestion()
    {
        return (question);
    }

    public int GetCorrectAnswerIndex()
    {
        return (rightAnswerIndex);
    }
    public string GetAnswer(int index)
    {
        return (answers[index]);
    }

}
