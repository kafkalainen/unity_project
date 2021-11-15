using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;
    [Header("Button Colours")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Scoring")]
    [SerializeField] Slider progressBar;

    public bool isComplete;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            if (progressBar.value >= progressBar.maxValue)
            {
                isComplete = true;
                return ;
            }
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
        questionText.text = currentQuestion.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetAnswerButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score:\n" + scoreKeeper.GetCurrentScore() + "%";
    }

    public void DisplayAnswer(int index)
    {
        int correctAnswer = currentQuestion.GetCorrectAnswerIndex();
        if (index == correctAnswer)
        {
            questionText.text = "Correct!";
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            string correctAnswerStr = currentQuestion.GetAnswer(correctAnswer);
            questionText.text =
                "Wrong! Correct answer is: \n" + correctAnswerStr;
        }
        Image buttonImage = answerButtons[correctAnswer].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
    }
    public void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetAnswerButtonState(true);
            SetDefaultButtonSprites();
            GetQuestionFromList();
            DisplayQuestion();
            progressBar.value++;
            scoreKeeper.IncrementSeenQuestions();
        }
    }

    //GetRandomQuestion()
    // int index = Random.Range(0, questions.Count);
    // currentQuestion = questions[index];
    // if (questions.Contains(currentQuestion))
    // {
    //     questions.Remove(currentQuestion);
    // }

    void GetQuestionFromList()
    {
        currentQuestion = questions[0];
        if (questions.Count > 0)
            questions.RemoveAt(0);
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
