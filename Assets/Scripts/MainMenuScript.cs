using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas howToPlayCanvas;

    public void closeHowToPlayCanvas()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        howToPlayCanvas.gameObject.SetActive(false);
    }

    public void openHowToPlayCanvas()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        howToPlayCanvas.gameObject.SetActive(true);
    }

    public void startGame()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}