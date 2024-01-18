using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AnswerButton : MonoBehaviour
{
    public int correctSolved = 0;
    private int questionsSolved = 0;
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
        switchQuestion();
        questionsSolved++;
        if (isCorrect)
        {
            Debug.Log("CORRECT ANSWER");
            correctSolved++;
        }
        else
        {
            Debug.Log("WRONG ANSWER");
        }
    }
    public void switchQuestion()
    {
        Debug.Log("Switching question " + questionsSolved);
        questionSetup.SelectNewQuestion();
        questionSetup.SetQuestionValues();
        questionSetup.SetAnswerValues();
    }

}