using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLose : MonoBehaviour
{
    private int count = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            Debug.Log("Wall in zone");
            count++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            Debug.Log("Wall out of zone");
            count--;
            if (count <= 0)
            {
                Debug.Log("You Lose");
                loseGame();
            }
        }
    }

    [SerializeField] private Canvas loserCanvas;
    private void loseGame()
    {
        Time.timeScale = 0;
        loserCanvas.gameObject.SetActive(true);
    }

}