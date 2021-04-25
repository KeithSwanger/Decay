using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class Questionaire : MonoBehaviour
{
    public UnityAction QuestionaireCompleted;
    private MainMenuInfo mainMenuInfo;

    public TMP_Text questionTextDepression;
    public TMP_Text questionTextDisease;
    public TMP_Text questionTextDistress;
    public TMP_Text questionTextDebt;
    public TMP_Text questionTextDeath;


    public TMP_Text currentQuestion;

    bool isCurrentQuestionAnswered = false;
    bool isCurrentQuestionFaded = false;

    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    bool isQuestionaireComplete = false;


    List<TMP_Text> questions = new List<TMP_Text>();
    int currentQuestionIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        mainMenuInfo = MainMenuInfo.Instance;

        questions.Add(questionTextDepression);
        questions.Add(questionTextDisease);
        questions.Add(questionTextDistress);
        questions.Add(questionTextDebt);
        questions.Add(questionTextDeath);

        foreach (TMP_Text q in questions)
        {
            q.alpha = 0f;
        }

        button0.onClick.AddListener(OnButton0Click);
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
        button3.onClick.AddListener(OnButton3Click);
        button4.onClick.AddListener(OnButton4Click);
    }

    private void Update()
    {
        if (!isCurrentQuestionAnswered)
        {

            if (currentQuestion.alpha != 1f)
            {
                float newAlpha = currentQuestion.alpha + Time.deltaTime;

                if (newAlpha > 1f)
                {
                    newAlpha = 1f;
                }

                currentQuestion.alpha = newAlpha;
            }
        }
        else
        {
            if (currentQuestion.alpha > 0f)
            {
                float newAlpha = currentQuestion.alpha - Time.deltaTime;
                if (newAlpha < 0f)
                {
                    newAlpha = 0f;

                    // QUESTION ANSWERED AND FADED OUT, GO TO NEXT QUESTION
                    GoToNextQuestion();
                }

                currentQuestion.alpha = newAlpha;
            }
        }


    }

    void OnButton0Click()
    {
        CompleteQuestionAndSetValue(4);
    }
    void OnButton1Click()
    {
        CompleteQuestionAndSetValue(3);

    }
    void OnButton2Click()
    {
        CompleteQuestionAndSetValue(2);

    }
    void OnButton3Click()
    {
        CompleteQuestionAndSetValue(1);

    }
    void OnButton4Click()
    {
        CompleteQuestionAndSetValue(0);

    }

    void CompleteQuestionAndSetValue(int val)
    {
        if (isCurrentQuestionAnswered)
        {
            return;
        }


        if (currentQuestion == questionTextDepression)
        {
            mainMenuInfo.depression = val;
        }
        else if (currentQuestion == questionTextDisease)
        {
            mainMenuInfo.disease = val;
        }
        else if (currentQuestion == questionTextDistress)
        {
            mainMenuInfo.distress = val;
        }
        else if (currentQuestion == questionTextDebt)
        {
            mainMenuInfo.debt = val;
        }
        Debug.Log($"answered with: {val}");

        isCurrentQuestionAnswered = true;
    }

    private void GoToNextQuestion()
    {

        if (isQuestionaireComplete)
        {
            return;
        }


        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            currentQuestion = questions[currentQuestionIndex];
            isCurrentQuestionAnswered = false;
            isCurrentQuestionFaded = false;
        }
        else
        {
            isQuestionaireComplete = true;
            //QUESTIONAIRE COMPLETE, START GAME!

            QuestionaireCompleted?.Invoke();
        }
    }
}
