using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestControll : MonoBehaviour
{
    [SerializeField] private QuestUI questUI;
    [SerializeField] private TowerUpgrade towergrade;
    [SerializeField] private List<QuestPanel> questPanel;
    [SerializeField] private List<GameObject> Attention;
    [SerializeField] private GameObject QuestPanel;
    public int m_currentRaid { get; set; } = 0;
    public long m_currentGold { get; set; } = 0;


    public void OpenQuestPanel()
    {
        questUI.Initialise(m_currentGold, m_currentRaid);
        foreach (var item in questPanel)
        {
            item.GetRaidInfo(towergrade.currentGrade, m_currentRaid, m_currentGold);
        }
        transform.GetChild(0).gameObject.SetActive(true);
        ActivateAttentionIcon(false);
    }

    public void InitialiseQuest()
    {
        foreach (var item in questPanel)
        {
            item.GetRaidInfo(towergrade.currentGrade, m_currentRaid, m_currentGold);
        }
    }
    public void RaidConplete(long goldValue)
    {
        m_currentGold += goldValue;
        questUI.GoldValue(goldValue);
        InitialiseQuest();
        if(!QuestPanel.activeSelf)
            CheckAttention();
    }
    public void RaidCount()
    {
        m_currentRaid++;
        questUI.RaidValue(m_currentRaid);
        if(m_currentRaid == 25)
        {
            MainTutorial.instance.THirdTutorialSteps();
        }

    }
    public void OfflineRaids(int value) => m_currentRaid += value;
    public List<QuestPanel> GetQuestPanels() => questPanel;
    public void CheckAttention()
    {
        for (int i = 0; i < questPanel.Count; i++)
        {
            if (questPanel[i].CheckCompleteQuest())
                ActivateAttentionIcon(true);
        }
    }
    private void ActivateAttentionIcon(bool isActivate)
    {
        if(isActivate)
        {
            for (int i = 0; i < Attention.Count; i++)
            {
                Attention[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < Attention.Count; i++)
            {
                Attention[i].SetActive(false);
            }
        }
    }
}
