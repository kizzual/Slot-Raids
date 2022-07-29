using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    private long m_goldToGrade;
    public int currentGrade { get; set; }
    private Tower_UI m_tower_ui;
    private void Start()
    {
        m_tower_ui = GetComponent<Tower_UI>();
        /*     if (PlayerPrefs.HasKey("TowerLvl"))
                 currentGrade = PlayerPrefs.GetInt("TowerLvl");
             else
                 currentGrade = 0;*/
        currentGrade = 0;
        CheckGoldToGrade();
        GlovalEventSystem.UpgradeTower(currentGrade);
        m_tower_ui.ChangeTowerSprite(currentGrade, m_goldToGrade);
    }
    public void UpgradeTower()
    {
        if(Gold.GetCurrentGold() >= m_goldToGrade && currentGrade < 9)
        {
            currentGrade++;
            GlovalEventSystem.UpgradeTower(currentGrade);
            Debug.Log("EROR");
            Gold.SpendGold(m_goldToGrade);
            PlayerPrefs.SetInt("TowerLvl", currentGrade);
            CheckGoldToGrade();
            m_tower_ui.ChangeTowerSprite(currentGrade, m_goldToGrade);
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
