using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Text questionText;

    public void Start()
    {
        GenerateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void GenerateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        questionText.text = QnA[currentQuestion].Question;
        SetAnswers();
    }
}