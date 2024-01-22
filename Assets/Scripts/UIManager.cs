using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider BudgetSlider;
    public Text BudgetText;

    public Gradient myGradient;

    public Button WoodButton;
    public Button BrickButton;
    public Button ConcreteButton;
    public Button SteelButton;

    public BarCreator barCreator;


    public void UpdateBudgetUI(float CurrentBudget, float LevelBudget)
    {
        BudgetText.text = Mathf.FloorToInt(CurrentBudget).ToString() + "€";
        BudgetSlider.value = CurrentBudget / LevelBudget;
        BudgetSlider.fillRect.GetComponent<Image>().color = myGradient.Evaluate(BudgetSlider.value);
    }

    public void ChangeBar(int myBarType)
    {
        if (myBarType == 0)
        {
            WoodButton.GetComponent<Outline>().enabled = true;
            BrickButton.GetComponent<Outline>().enabled = false;
            ConcreteButton.GetComponent<Outline>().enabled = false;
            SteelButton.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.WoodBar;
        }
        else if (myBarType == 1)
        {
            WoodButton.GetComponent<Outline>().enabled = false;
            BrickButton.GetComponent<Outline>().enabled = true;
            ConcreteButton.GetComponent<Outline>().enabled = false;
            SteelButton.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.BrickBar;
        }
        else if (myBarType == 2)
        {
            WoodButton.GetComponent<Outline>().enabled = false;
            BrickButton.GetComponent<Outline>().enabled = false;
            ConcreteButton.GetComponent<Outline>().enabled = true;
            SteelButton.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.ConcreteBar;
        }
        else if (myBarType == 3)
        {
            WoodButton.GetComponent<Outline>().enabled = false;
            BrickButton.GetComponent<Outline>().enabled = false;
            ConcreteButton.GetComponent<Outline>().enabled = false;
            SteelButton.GetComponent<Outline>().enabled = true;
            barCreator.BarToInstantiate = barCreator.SteelBar;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ConcreteButton.onClick.Invoke();
    }

    // Update is called once per frame
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Play()
    {
        Time.timeScale = 1;
    }
}