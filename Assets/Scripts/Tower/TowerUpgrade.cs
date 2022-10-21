using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgrade : MonoBehaviour
{
    private long m_goldToGrade;
    public int currentGrade { get; set; }
    private Tower_UI m_tower_ui;
    public Raid_control raidControl;
    public GameObject BoostTower;
    public GameObject Boost;
    public GameObject InactiveButton;
    public Boost_Controll boostControl;
    [SerializeField] private ParticleSystem _upgradeParticle;
    [SerializeField] private List<ParticleSystem> boostParticle;
    [SerializeField] private GameObject ManaBottle;
    [SerializeField] private GameObject ManaBottle_deactive;
    [SerializeField] private QuestControll questControll;
    public Text test_4;
    private void Awake()
    {
       
    }
    private void OnEnable()
    {
        if (Gold.GetCurrentGold() >= m_goldToGrade)
        {
            InactiveButton.SetActive(false);
        }
        else
            InactiveButton.SetActive(true);
        if(BoostTower.activeSelf)
        {
            if (boostControl.CurrentBoost != null)
            {
                if (boostControl.CurrentBoost.isActive)
                {
                    foreach (var item in boostParticle)
                    {
                        item.Play();
                    }
                }
                else
                {
                    foreach (var item in boostParticle)
                    {
                        item.Stop();
                    }
                }
            }
        }
        
    }
    public void CheckBoostParticle()
    {
        if (BoostTower.activeSelf)
        {
            if (boostControl.CurrentBoost != null)
            {
                if (boostControl.CurrentBoost.isActive)
                {
                    foreach (var item in boostParticle)
                    {
                        item.Play();
                    }
                }
                else
                {
                    foreach (var item in boostParticle)
                    {
                        item.Stop();
                    }
                }
            }
        }
    }
    public void Initialise()
    {
        if (PlayerPrefs.HasKey("BoostTower"))
            BoostTower.SetActive(true);
        m_tower_ui = GetComponent<Tower_UI>();
        if (PlayerPrefs.HasKey("TowerLvl"))
        {
            currentGrade = PlayerPrefs.GetInt("TowerLvl");
        }
        else
        {
            currentGrade = 0;
        }
        CheckGoldToGrade();
        m_tower_ui.ChangeTowerSprite(currentGrade, m_goldToGrade);
        raidControl.CheckGrade(currentGrade);


    }
    public void UpgradeTower()
    {
        if (Gold.GetCurrentGold() >= m_goldToGrade && currentGrade < 9)
        {
            Gold.SpendGold(m_goldToGrade);
            currentGrade++;
            PlayerPrefs.SetInt("TowerLvl", currentGrade);
            CheckGoldToGrade();
            m_tower_ui.ChangeTowerSprite(currentGrade, m_goldToGrade);
            
       //     GlovalEventSystem.TutorialSteps(1);
            SoundControl._instance.UpgradeTower();
            _upgradeParticle.Play();
            questControll.InitialiseQuest();
            questControll.CheckAttention();
        }
        else
        {
            SoundControl._instance.NoMoney();
        }
    }

    public int GetTowerGrade() => currentGrade;
    private void CheckGoldToGrade()
    {
        if (currentGrade == 0)
        {
            m_goldToGrade = 1000;  // 1000
        }
        else if (currentGrade == 1)
        {
            m_goldToGrade = 10000;  // 10.000
        }
        else if (currentGrade == 2)
        {
            m_goldToGrade = 100000; // 100.000
        }
        else if (currentGrade == 3)
        {
            m_goldToGrade = 1000000; // 1.000.000
        }
        else if (currentGrade == 4)
        {
            m_goldToGrade = 10000000; // 10.000.000
        }
        else if (currentGrade == 5)
        {
            m_goldToGrade = 100000000; // 100.000.000
        }
        else if (currentGrade == 6)
        {
            m_goldToGrade = 1000000000; // 1.000.000.000
        }
        else if (currentGrade == 7)
        {
            m_goldToGrade = 10000000000; // 10.000.000.000
        }
        else if (currentGrade == 8)
        {
            m_goldToGrade = 100000000000; // 100.000.000.000
        }
    }
}
