using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    private BuildManager _buildManager;
    public int[,] shopItems = new int[5, 5];
    [SerializeField] private Text PointsTxt;
    [SerializeField] private int overRidePointsTest;
    
    void Start()
    {
        _buildManager = FindObjectOfType<BuildManager>();

        if (_buildManager == null)
        {
            Debug.Log("no build manager find");
        }

        PointsTxt.text = "Points:" + _buildManager.Point;

        //item ids
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //prices
        shopItems[2, 1] = 1;
        shopItems[2, 2] = 1;
        shopItems[2, 3] = 1;
        shopItems[2, 4] = 1;

        //quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>()
            .currentSelectedGameObject;
        if (_buildManager.Point >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            _buildManager.Point -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            PointsTxt.text = "Points: " + _buildManager.Point.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text =
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
    
}