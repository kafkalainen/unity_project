using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly;
    [Header("Button Colours")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetAnswerButtonState(false);
        }
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
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetAnswerButtonState(false);
        timer.CancelTimer();
    }

    public void DisplayAnswer(int index)
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
