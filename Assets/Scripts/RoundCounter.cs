using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    
}