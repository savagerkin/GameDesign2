using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float LevelBudget = 300;
    private float CurrentBudget = 0;
    public UIManager myUIManager;

    static public Dictionary<Vector2, Points> AllPoints = new Dictionary<Vector2, Points>();

    //After this point its for declaring game losing or game winning
    [SerializeField] private BoxCollider2D minimumBarSquare;
    [SerializeField] private Transform MaxHeight = null;
    [SerializeField] private Transform MinHeight = null;
    private float middleOfMaxMin;
    [SerializeField] private BarCreator _barCreator;
    [SerializeField] private float roundNumber = 1;

    private BuildManager _buildManager;
    private RoundCounter _roundCounter;

    void Awake()
    {
        _buildManager = FindObjectOfType<BuildManager>();

        if (_buildManager == null)
        {
            Debug.Log("no build manager find");
        }

        LevelBudget += 300 * _buildManager.Point;
        CurrentBudget = LevelBudget;

        myUIManager.UpdateBudgetUI(CurrentBudget, LevelBudget);
        AllPoints.Clear();
        Time.timeScale = 0;

        //Creating the postion of losing square
        _roundCounter = FindObjectOfType<RoundCounter>();
        roundNumber = _roundCounter.RoundCount;
        var position = MinHeight.transform.position;
        position.y = (float)(roundNumber / 0.75);
        if (position.y >= 10)
        {
            position.y = 10;
        }
        MinHeight.transform.position = position;
        middleOfMaxMin = (MaxHeight.transform.position.y - MinHeight.transform.position.y) / 2;
        var vector3 = minimumBarSquare.transform.position;
        vector3.y = middleOfMaxMin + MinHeight.transform.position.y;
        minimumBarSquare.transform.position = vector3;

        var size = minimumBarSquare.size;
        size.y = middleOfMaxMin * 2;
        minimumBarSquare.size = size;
        if (SceneManager.GetActiveScene().name == "Building")
        {
            _roundCounter.RoundCount++;
        }
    }

    public bool CanPlaceItem(float itemCost)
    {
        if (itemCost > CurrentBudget)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void UpdateBudget(float itemCost)
    {
        CurrentBudget -= itemCost;
        myUIManager.UpdateBudgetUI(CurrentBudget, LevelBudget);
    }

    [SerializeField] private float testFloat = 0;


    public void Update()
    {

    }
}