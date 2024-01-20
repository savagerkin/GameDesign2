using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public PointManager pointManagter;
    private bool isCorrect;
    [SerializeField]private TextMeshProUGUI answerText;
    public QuestionSetup questionSetup;
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
        //switchQuestion();
        if (isCorrect)
        {
            Debug.Log("CORRECT ANSWER");
        }
        else
        {
            Debug.Log("WRONG ANSWER");
        }

        pointManagter.Counter++;

    }
    public void switchQuestion()
    {
        questionSetup.SelectNewQuestion();
        questionSetup.SetQuestionValues();
        questionSetup.SetAnswerValues();
    }

}