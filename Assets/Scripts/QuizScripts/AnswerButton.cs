using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField]
    private TextMeshProUGUI answerText;
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
        if (isCorrect)
        {
            Debug.Log("CORRECT ANSWER");
            switchQuestion();
        }
        else
        {
            Debug.Log("WRONG ANSWER");
        }
    }
    public void switchQuestion()
    {
        Debug.Log("Change answer process begin");
        questionSetup.SelectNewQuestion();
        questionSetup.SetQuestionValues();
        questionSetup.SetAnswerValues();

    }

}