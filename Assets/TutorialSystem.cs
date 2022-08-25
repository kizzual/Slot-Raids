using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> steps;
    [SerializeField] private List<GameObject> steps_openHero;
    [SerializeField] private List<GameObject> steps_openBoost;
    [SerializeField] private List<GameObject> steps_openLocation;
    [SerializeField] Raid_control raidControl;
    [SerializeField] Inventory_controll inventory_controll;
    [SerializeField] Item item;
    [SerializeField] Raid_button raiButton;
    public static TutorialSystem tutorSystem;
    public int m_currentIncdex_mainTutorial = 0;
    public int m_currentIndex_locationTutorial = 0;
    public int m_currentIndex_openHeroTutorial = 0;
    public int m_currentIndex_openBoostTutorial = 0;
    public GameObject ManaButton;
    public GameObject ManaButton_disable;
    private int save = 0;
    private void Awake()
    {
        tutorSystem = this;
        if (PlayerPrefs.HasKey("TutorSave") && PlayerPrefs.GetInt("TutorSave") == 4)
        {
            save = 4;
            m_currentIncdex_mainTutorial = steps.Count;
            m_currentIndex_openHeroTutorial = steps_openHero.Count;
            m_currentIndex_openBoostTutorial = steps_openBoost.Count;
            m_currentIndex_locationTutorial = steps_openLocation.Count;
          
        }
    }
    public void MainTutorial()
    {
        if (m_currentIncdex_mainTutorial < steps.Count)
        {
            if (m_currentIncdex_mainTutorial == 0)
            {
                steps[0].SetActive(true);

            }
            else if (m_currentIncdex_mainTutorial == 11)
            {
                steps[m_currentIncdex_mainTutorial - 1].SetActive(false);
                steps[m_currentIncdex_mainTutorial ].SetActive(true);

                StartCoroutine(ActiveDelay(steps[m_currentIncdex_mainTutorial], 3.5f));
            }
            else if (m_currentIncdex_mainTutorial == 12)
            {
                raiButton.PauseRaid();
                steps[m_currentIncdex_mainTutorial - 1].SetActive(false);
                steps[m_currentIncdex_mainTutorial].SetActive(true);
            }
            else if(m_currentIncdex_mainTutorial == 13)
            {

                inventory_controll.ReturnItem(item);
                inventory_controll.ReturnItem(item);
                steps[m_currentIncdex_mainTutorial - 1].SetActive(false);
                steps[m_currentIncdex_mainTutorial].SetActive(true);
               
            }
            else if(m_currentIncdex_mainTutorial == 27)
            {
                raiButton.PauseRaid();
                steps[m_currentIncdex_mainTutorial - 1].SetActive(false);
                steps[m_currentIncdex_mainTutorial].SetActive(true);
            }
            else if(m_currentIncdex_mainTutorial == 30)
            {
                raiButton.GoToAutoRaid();
                steps[m_currentIncdex_mainTutorial - 1].SetActive(false);
                steps[m_currentIncdex_mainTutorial].SetActive(true);
            }
            else
            {
                steps[m_currentIncdex_mainTutorial - 1].SetActive(false);
                steps[m_currentIncdex_mainTutorial].SetActive(true);
            }
            m_currentIncdex_mainTutorial++;
            if(m_currentIncdex_mainTutorial == steps.Count)
            {
                Debug.Log("SAVE =  " + save);
                save++;
                PlayerPrefs.SetInt("TutorSave", save);
                OpenHeroTutorial();
            }
  
        }
    }
    IEnumerator ActiveDelay(GameObject step, float time)
    {
        yield return new WaitForSeconds(time);
        step.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        step.transform.GetChild(0).gameObject.SetActive(true);
        step.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void BoostTutorial()
    {
        if(m_currentIndex_openBoostTutorial < steps_openBoost.Count)
        {
            Debug.Log("Boost Tutor");
            if (m_currentIndex_openBoostTutorial == 0)
            {
                raiButton.PauseRaid();
                steps_openBoost[m_currentIndex_openBoostTutorial].SetActive(true);
              
            }
            else if(m_currentIndex_openBoostTutorial == 4)
            {
                raiButton.GoToAutoRaid();
                steps_openBoost[m_currentIndex_openBoostTutorial - 1].SetActive(false);
                steps_openBoost[m_currentIndex_openBoostTutorial].SetActive(true);
            }
            else if(m_currentIndex_openBoostTutorial == 5)
            {
                steps_openBoost[m_currentIndex_openBoostTutorial - 1].SetActive(false);
                steps_openBoost[m_currentIndex_openBoostTutorial].SetActive(true);
                ManaButton.SetActive(true);
                ManaButton_disable.SetActive(false);
            }
            else
            {
                steps_openBoost[m_currentIndex_openBoostTutorial - 1].SetActive(false);
                steps_openBoost[m_currentIndex_openBoostTutorial].SetActive(true);
            }
            m_currentIndex_openBoostTutorial++;
            if(m_currentIndex_openBoostTutorial == steps_openBoost.Count)
            {
                save++;
                PlayerPrefs.SetInt("TutorSave", save);
            }
        }
    }
    public void LocationTutorial()
    {
        if (m_currentIndex_locationTutorial < steps_openLocation.Count)
        {
            Debug.Log("LocationTutor");
            if (m_currentIndex_locationTutorial == 0)
            {
                steps_openLocation[m_currentIndex_locationTutorial].SetActive(true);
            }  
            else
            {
                steps_openLocation[m_currentIndex_locationTutorial - 1].SetActive(false);
                steps_openLocation[m_currentIndex_locationTutorial].SetActive(true);
            }
            m_currentIndex_locationTutorial++;
            if (m_currentIndex_locationTutorial == steps_openLocation.Count)
            {
                save++;
                PlayerPrefs.SetInt("TutorSave", save);
            }
        }
    }
    public void OpenHeroTutorial()
    {
        if (m_currentIndex_openHeroTutorial < steps_openHero.Count)
        {
            Debug.Log("Hero tutorial");
            if (m_currentIndex_openHeroTutorial == 0)
            {
                steps_openHero[m_currentIndex_openHeroTutorial].SetActive(true);
            }
    /*        else if(m_currentIndex_openHeroTutorial == 5)
            {
                steps_openHero[m_currentIndex_openHeroTutorial - 1].SetActive(false);
                if (raidControl.CheckWinPrize()[0].isOpened && raidControl.CheckWinPrize()[0].m_currentHero == null)
                {
                    steps_openHero[5].SetActive(true);
                    steps_openHero[5].SetActive(true);
                    m_currentIndex_openHeroTutorial++;

                }
                else if (raidControl.CheckWinPrize()[1].isOpened && raidControl.CheckWinPrize()[0].m_currentHero == null)
                {
                    steps_openHero[6].SetActive(true);
                    m_currentIndex_openHeroTutorial++;
                }
            }*/
            else
            {
                steps_openHero[m_currentIndex_openHeroTutorial - 1].SetActive(false);
                steps_openHero[m_currentIndex_openHeroTutorial].SetActive(true);
            }
            m_currentIndex_openHeroTutorial++;
            if (m_currentIndex_openHeroTutorial == steps_openHero.Count)
            {
                raiButton.GoToAutoRaid();
                save++;
                PlayerPrefs.SetInt("TutorSave", save);
            }
        }
    }
}
