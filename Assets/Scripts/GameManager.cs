using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float LevelBudget = 1000;
    public float CurrentBudget = 0;
    public UIManager myUIManager;
    static public Dictionary<Vector2, Points> AllPoints = new Dictionary<Vector2, Points>();
    // Start is called before the first frame update
    void Awake()
    {
        CurrentBudget = LevelBudget;
        myUIManager.UpdateBudgetUI(CurrentBudget, LevelBudget);
        AllPoints.Clear();
        Time.timeScale = 0;
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

}
