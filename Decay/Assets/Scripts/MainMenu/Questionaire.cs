using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Questionaire : MonoBehaviour
{
    private MainMenuInfo mainMenuInfo;

    public TMP_Text questionTextDepression;
    public TMP_Text questionTextDisease;
    public TMP_Text questionTextDistress;
    public TMP_Text questionTextDebt;

    public TMP_Text currentQuestion;

    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    bool areButtonsActive = false;

    List<TMP_Text> questions = new List<TMP_Text>();

    // Start is called before the first frame update
    void Awake()
    {
        mainMenuInfo = MainMenuInfo.Instance;

        questions.Add(questionTextDepression);
        questions.Add(questionTextDisease);
        questions.Add(questionTextDistress);
        questions.Add(questionTextDebt);

        foreach(TMP_Text q in questions)
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
        if(currentQuestion.alpha != 1f)
        {
            float newAlpha = currentQuestion.alpha + Time.deltaTime;

            if(newAlpha > 1f)
            {
                newAlpha = 1f;
            }

            currentQuestion.alpha = newAlpha;
        }
    }

    void OnButton0Click()
    {
        SetValueForCurrentQuestion(4);
    }
    void OnButton1Click()
    {
        SetValueForCurrentQuestion(3);

    }
    void OnButton2Click()
    {
        SetValueForCurrentQuestion(2);

    }
    void OnButton3Click()
    {
        SetValueForCurrentQuestion(1);

    }
    void OnButton4Click()
    {
        SetValueForCurrentQuestion(0);

    }

    void SetValueForCurrentQuestion(int val)
    {
        if(currentQuestion == questionTextDepression)
        {
            mainMenuInfo.depression = val;
        }
        else if(currentQuestion == questionTextDisease)
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
    }

}
