using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTutorial : MonoBehaviour
{
    public static MainTutorial instance;
    [SerializeField] private List<GameObject> mainTutorial;
    [SerializeField] private List<GameObject> secondTutorial;
    [SerializeField] private List<GameObject> thirdTutorial;
    [SerializeField] private GameObject Tutorial_1_5;
    [SerializeField] private GameObject Tutorial_1_7;
    [SerializeField] private GameObject Tutorial_2_6;
    [SerializeField] private GameObject Tutorial_2_8;
    [SerializeField] private GameObject Tutorial_3_2;
    [SerializeField] private GameObject Tutorial_3_4;
    [SerializeField] private Raid_button raid_Button;
    [SerializeField] private GameObject manaBottle;
    [SerializeField] private GameObject cardTower;
    [SerializeField] private GameObject boostTower;
    [SerializeField] private BaseLoader baseLoader;
    [SerializeField] private SwitchTabs switchTabs;

    public int mainStep = 0;
    public int secondStep = 0;
    public int thirdStep = 0;
    public bool mainTutorIsEnded = false;
    public bool secondTutorIsEnded = false;
    public bool thirdTutorIsEnded = false;
    void Start()
    {
        instance = this;
        MainTutorialSteps();
    }

    public void MainTutorialSteps()
    {
        Tutorial_1_5.SetActive(false);
        Tutorial_1_7.SetActive(false);

        if (mainStep != 26)
        {
            if (mainStep > 0)
            {
                mainTutorial[mainStep - 1].SetActive(false);
                mainTutorial[mainStep].SetActive(true);
                if (mainStep == 5)
                    Tutorial_1_5.SetActive(true);
                if (mainStep == 7)
                    Tutorial_1_7.SetActive(true);
                if (mainStep == 15)
                {
                    raid_Button.PauseRaid();
                    StartCoroutine(step_115_21());
                }
            }
            else
                mainTutorial[mainStep].SetActive(true);
            mainStep++;
        }
        else
        {
            baseLoader.SaveAll();
            mainTutorial[mainStep - 1].SetActive(false);
            mainTutorIsEnded = true;
            PlayerPrefs.SetInt("first", 1);
        }
    }
    public void SecondTutorSteps()
    {

        if (switchTabs.CurrentPanel == 2 && secondStep == 0)
        {
            secondTutorial.RemoveAt(0);
        }

        if (secondStep != 13)
        {
            Tutorial_2_6.SetActive(false);
            Tutorial_2_8.SetActive(false);
            manaBottle.SetActive(true);
            if (secondStep > 0)
            {
                secondTutorial[secondStep - 1].SetActive(false);
                secondTutorial[secondStep].SetActive(true);
                if (secondStep == 5)
                    Tutorial_2_6.SetActive(true);
                if (secondStep == 7)
                    Tutorial_2_8.SetActive(true);
                if (secondStep == 8)
                {
                    PlayerPrefs.SetInt("BoostTower", 1);
                    boostTower.SetActive(true);
                }

            }
            else
                secondTutorial[secondStep].SetActive(true);
            secondStep++;
        }
        else
        {
            secondTutorial[secondStep - 1].SetActive(false);
            secondTutorIsEnded = true;
            baseLoader.SaveAll();
            PlayerPrefs.SetInt("BoostTower", 1);
            PlayerPrefs.SetInt("second", 1);
        }
    }
    public void THirdTutorialSteps()
    {
        if (thirdStep != 12)
        {

            Tutorial_3_2.SetActive(false);
            Tutorial_3_4.SetActive(false);

            if (thirdStep > 0)
            {
                thirdTutorial[thirdStep - 1].SetActive(false);
                thirdTutorial[thirdStep].SetActive(true);
                if (thirdStep == 1)
                    Tutorial_3_2.SetActive(true);
                if (thirdStep == 3)
                    Tutorial_3_4.SetActive(true);
            }
            else
                thirdTutorial[thirdStep].SetActive(true);
            thirdStep++;
        }
        else
        {
            thirdTutorial[thirdStep - 1].SetActive(false);
            thirdTutorIsEnded = true;
            baseLoader.SaveAll();
            PlayerPrefs.SetInt("third", 1);
        }
    }

    IEnumerator step_115_21()
    {
        yield return new WaitForSeconds(1f);
        MainTutorialSteps();
    }
    public void Initialise()
    {
        if (PlayerPrefs.HasKey("first"))
        {
            mainStep = 26;
            mainTutorIsEnded = true;
        }
        if (PlayerPrefs.HasKey("second"))
        {
            secondStep = 13;
            manaBottle.SetActive(true);
            cardTower.SetActive(true);
            secondTutorIsEnded = true;
        }
        if (PlayerPrefs.HasKey("third"))
        {
            thirdStep = 12;
            thirdTutorIsEnded = true;
        }
    }
}
