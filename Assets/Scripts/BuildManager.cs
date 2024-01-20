using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private int correctCounter = 0;
    [SerializeField] private Text _text;


    public int Point
    {
        get { return this.correctCounter; }
        set { correctCounter = value; }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {
        _text.text = correctCounter.ToString();
    }
}