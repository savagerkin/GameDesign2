using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private int correctCounter = 0;
    
    public int Point
    {
        get { return this.correctCounter; }
        set { correctCounter = value; }
    }
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}