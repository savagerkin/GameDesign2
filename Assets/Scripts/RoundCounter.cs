using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundCounter : MonoBehaviour
{
    private int roundCount = 0;

    public int RoundCount
    {
        get { return this.roundCount; }
        set { roundCount = value; }
    }

    private static RoundCounter _roundManager;

    private void Awake()
    {
        if (_roundManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _roundManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            roundCount = 0;
        }
    }
}