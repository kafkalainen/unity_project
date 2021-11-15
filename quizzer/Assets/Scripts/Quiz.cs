using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;

    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        GetNextQuestion();
    }

    public void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        int correctAnswer = question.GetCorrectAnswerIndex();
        if (index == correctAnswer)
            questionText.text = "Correct!";
        else
        {
            string correctAnswerStr = question.GetAnswer(correctAnswer);
            questionText.text =
                "Wrong! Correct answer is: \n" + correctAnswerStr;
        }
        Image buttonImage = answerButtons[correctAnswer].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
        SetAnswerButtonState(false);
    }
    public void GetNextQuestion()
    {
        SetAnswerButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    public void SetAnswerButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    public void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
