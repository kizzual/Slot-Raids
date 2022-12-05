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
    [SerializeField] private Boost_Controll Boost_Controll;
    [SerializeField] private BaseLoader baseLoader;
    [SerializeField] private SwitchTabs switchTabs;
    [SerializeField] private ParticleSystem ps; 

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

        if (mainStep != 27)
        {
            if (mainStep > 0)
            {
                Debug.Log("STEP = " + mainStep);
                mainTutorial[mainStep - 1].SetActive(false);
                mainTutorial[mainStep].SetActive(true);
                if (mainStep == 5)
                    Tutorial_1_5.SetActive(true);
                if (mainStep == 7)
                    Tutorial_1_7.SetActive(true);
                if (mainStep == 12)
                    StartCoroutine(step_112_13());
                if (mainStep == 13)
                    raid_Button.GoToAutoRaid();
                if (mainStep == 15)
                {
                    raid_Button.PauseRaid();
                    StartCoroutine(step_115_21());
                }
                if (mainStep == 16)
                    raid_Button.PauseRaid();
                if (mainStep == 17)
                    raid_Button.PauseRaid();
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

        if (secondStep != 13)
        {
            if(secondStep == 0)
            {
                switchTabs.ActivateCurrentButton(2);
                Boost_Controll.BuyBottles(1);
            }
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
        if (thirdStep != 16)
        {
                raid_Button.PauseRaid();

            Tutorial_3_2.SetActive(false);
            Tutorial_3_4.SetActive(false);

            if (thirdStep > 0)
            {
                thirdTutorial[thirdStep - 1].SetActive(false);
                thirdTutorial[thirdStep].SetActive(true);
                if (thirdStep == 2)
                {
                    ps.Play();
                    Gold.AddGold(50000);
                }
                if (thirdStep == 5)
                    Tutorial_3_2.SetActive(true);
                if (thirdStep == 7)
                    Tutorial_3_4.SetActive(true);
                if (thirdStep == 14)
                    raid_Button.PauseRaid();
                if (thirdStep == 15)
                    raid_Button.GoToAutoRaid();



            }
            else
                thirdTutorial[thirdStep].SetActive(true);
            thirdStep++;
        }
        else
        {
            raid_Button.GoToAutoRaid();
            thirdTutorial[thirdStep - 1].SetActive(false);
            thirdTutorIsEnded = true;
            baseLoader.SaveAll();
            PlayerPrefs.SetInt("third", 1);
        }
    }
    IEnumerator step_112_13()
    {
        yield return new WaitForSeconds(2f);
        raid_Button.PauseRaid();
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
            mainStep = 27;
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
