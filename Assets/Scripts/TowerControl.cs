using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerControl : MonoBehaviour
{
    [SerializeField] private Text numberOfGradeTower_text;
    [SerializeField] private Text countToGrade_text;
    [SerializeField] private List<Image> GradeTower_image;
    [SerializeField] private ScrollingController scrollingController;
    public int currentGradeTower;
    private long CountToGrade_int = 1000;

    public void Initialise()
    {
        if (!PlayerPrefs.HasKey("tower"))
        {
            CountToGrade_int = 1000;
            for (int i = 0; i < GradeTower_image.Count; i++)
            {
                if (i == 0)
                {
                    GradeTower_image[i].enabled = true;
                }
                else
                {
                    GradeTower_image[i].enabled = false;
                }
            }
        }
        else
        {
            currentGradeTower = PlayerPrefs.GetInt("tower");
            PriceGrade();
            for (int i = 0; i < GradeTower_image.Count; i++)
            {
                if (i <= currentGradeTower)
                {
                    GradeTower_image[i].enabled = true;
                }
                else
                {
                    GradeTower_image[i].enabled = false;
                }
            }

        }
    }
    public int GetGradeTower() => currentGradeTower;

    private void OnEnable()
    {
     //   Initialise();
        DisplayTOwerInfo();
    }
    private void DisplayTOwerInfo()
    {

        numberOfGradeTower_text.text = ( 1 + currentGradeTower).ToString() + "/9 SLOTS";
        countToGrade_text.text = ConvertText.FormatNumb( CountToGrade_int);

        for (int i = 0; i < GradeTower_image.Count; i++)
        {
            if (i <= currentGradeTower)
            {
                GradeTower_image[i].enabled = true;
            }
            else
            {
                GradeTower_image[i].enabled = false;
            }
        }
        if(currentGradeTower == 9)
        {
            countToGrade_text.text = "MAX";
        }
    }
    public void GradeTower()
    {
        Debug.Log("before  ==  "+ Gold.GetCurrentGold());
        Debug.Log("To next grade   ==  "+ GoldToGrade());
        if (Gold.GetCurrentGold() >= GoldToGrade())
        {
            Gold.SpendGold(CountToGrade_int);
            currentGradeTower++;
            scrollingController.OpenSlot(currentGradeTower);
            PriceGrade();
            DisplayTOwerInfo();
        }
        Debug.Log("after =   "+Gold.GetCurrentGold());

    }
    private long GoldToGrade()
    {
        return CountToGrade_int;
    }
    private void PriceGrade()
    {
        if(currentGradeTower == 1)
        {
            CountToGrade_int = 10000;  // 10.000
        }
        else if (currentGradeTower == 2)
        {
            CountToGrade_int = 100000; // 100.000
        }
        else if (currentGradeTower == 3)
        {
            CountToGrade_int = 1000000; // 1.000.000
        }
        else if (currentGradeTower == 4)
        {
            CountToGrade_int = 10000000; // 10.000.000
        }
        else if (currentGradeTower == 5)
        {
            CountToGrade_int = 100000000; // 100.000.000
        }
        else if (currentGradeTower == 6)
        {
            CountToGrade_int = 1000000000; // 1.000.000.000
        }
        else if (currentGradeTower == 7)
        {
            CountToGrade_int = 10000000000; // 10.000.000.000
        }
        else if (currentGradeTower == 8)
        {
            CountToGrade_int = 100000000000; // 100.000.000.000
        }



    }
}
