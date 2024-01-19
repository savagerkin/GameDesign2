using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public int Counter = 0;
    public Text counterCorrectTxt;
    public void Update()
    {
        counterCorrectTxt.text = Counter.ToString();
    }
}
