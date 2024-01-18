using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public int currentPoints;
    public int pointsToAdd;
    
    
    public void setPoints()
    {
        
    }
    public void addPoints()
    {
        currentPoints += pointsToAdd;
    }
    
}
