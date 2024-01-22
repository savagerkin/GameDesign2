using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    private BuildManager _buildManager;
    [SerializeField] private int correctCounter = 0;

    public int Point
    {
        get { return this.correctCounter; }
        set { correctCounter = value; }
    }

    void Awake()
    {
        _buildManager = FindObjectOfType<BuildManager>();


        if (_buildManager == null || _buildManager == this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(_buildManager);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" )
        {
            Destroy(gameObject);
        }
    }
}