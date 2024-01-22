using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public BuildManager buildManager;
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answerText;
    public QuestionSetup questionSetup;
    [SerializeField] private Text _text;
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
        _text.text = buildManager.Point.ToString();
        if (buildManager.Point > 1)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void switchQuestion()
    {
        questionSetup.SelectNewQuestion();
        questionSetup.SetQuestionValues();
        questionSetup.SetAnswerValues();
    }
}