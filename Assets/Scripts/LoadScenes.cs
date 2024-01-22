using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadQuiz()
    {
        SceneManager.LoadScene("QuizAfterFirst");
    }
    public void LoadBuilding()
    {
        SceneManager.LoadScene("Building");
    }
}
