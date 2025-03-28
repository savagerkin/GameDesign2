using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    
    private BuildManager buildManager;
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answerText;
    public QuestionSetup questionSetup;
    [SerializeField] private Text _text;
    private int limit = 4;
    public void Awake()
    {
        buildManager = FindObjectOfType<BuildManager>();
        limit += buildManager.Point;
        _text.text = "Points:" + buildManager.Point.ToString();
    }
    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }
    
    public void OnClick()
    {
        if (isCorrect)
        {
            Debug.Log("CORRECT ANSWER");
        }
        else
        {
            Debug.Log("WRONG ANSWER");
        }
        buildManager.Point++;
        switchQuestion();
        _text.text = "Points:" + buildManager.Point.ToString();
        if (buildManager.Point > limit)
        {
            SceneManager.LoadScene("Building");
        }
    }

    public void switchQuestion()
    {
        questionSetup.SelectNewQuestion();
        questionSetup.SetQuestionValues();
        questionSetup.SetAnswerValues();
    }


}