using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float LevelBudget = 1000;
    public float CurrentBudget = 0;
    public UIManager myUIManager;

    static public Dictionary<Vector2, Points> AllPoints = new Dictionary<Vector2, Points>();

    //After this point its for declaring game losing or game winning
    [SerializeField] private BoxCollider2D minimumBarSquare;
    [SerializeField] private Transform MaxHeight = null;
    [SerializeField] private Transform MinHeight = null;
    private float middleOfMaxMin;
    [SerializeField] private BarCreator _barCreator;

    void Awake()
    {
        CurrentBudget = LevelBudget;
        myUIManager.UpdateBudgetUI(CurrentBudget, LevelBudget);
        AllPoints.Clear();
        Time.timeScale = 0;

        middleOfMaxMin = (MaxHeight.transform.position.y - MinHeight.transform.position.y) / 2;

        var vector3 = minimumBarSquare.transform.position;
        vector3.y = middleOfMaxMin + MinHeight.transform.position.y;
        minimumBarSquare.transform.position = vector3;

        var size = minimumBarSquare.size;
        size.y = middleOfMaxMin * 2;
        minimumBarSquare.size = size;
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


    public void Update()
    {
        if (Time.time == 0)
        {
            _barCreator.GameObject().SetActive(true);
        }
        else
        {
            _barCreator.GameObject().SetActive(false);
        }
    }
}