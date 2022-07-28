using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raid_control : MonoBehaviour
{
    [SerializeField] private List<Raid_UI> raid_slot;
    [SerializeField] private List<Text> winGold;
    [SerializeField] private List<Text> winSwords;
    [SerializeField] private List<Text> winShields;
    [SerializeField] private List<Text> winAmulets;

    private int m_currentSlotCount = 0;


    public void ActivateEvent()
    {
        GlovalEventSystem.OnUpgradeTower += OnGradeTower;
        GlovalEventSystem.OnHeroUpgrade += UpdateHeroStats;
        GlovalEventSystem.OnRemoveFromSlot += RemoveHero;
        GlovalEventSystem.OnSwitchLocation += Switchlocation;
        GlovalEventSystem.OnWinGold += DisplayWinGold;
        GlovalEventSystem.OnWinItems += DisplayWinItems;
        GlovalEventSystem.OnRotateComplete += RotateComplete;
    }

    private void OnEnable()
    {
        CheckSlots();
        foreach (var item in winSwords)
        {
            item.text = 0.ToString();
        }
        foreach (var item in winShields)
        {
            item.text = 0.ToString();
        }
        foreach (var item in winAmulets)
        {
            item.text = 0.ToString();
        }

    }
    public void CheckSlots()
    {
        foreach (var item in raid_slot)
        {
            item.OpenUnraidPanel();
            item.CheckSlot();
        }
    }
    public void UpdateHeroStats(Hero hero)
    {
        foreach (var item in raid_slot)
        {
            if (item.m_currentHero != null)
                if (item.m_currentHero == hero)
                    item.Initialise(hero);
        }
    }
    public void RemoveHero(int slotNum)
    {
        foreach (var item in raid_slot)
        {
            if(item.SlotNumber == slotNum)
            {
                item.RemoveHero();
            }
        }
        
    }
    public void Switchlocation(Zone zone)
    {
        foreach (var item in raid_slot)
        {
            item.SwitchBorder_andArrows();
        }
    }
    private void OnGradeTower(int gradeNumber)
    {
        for (int i = 0; i < gradeNumber; i++)
        {
            Debug.Log("GRADE");
            raid_slot[i].isOpened = true;
            raid_slot[i].CheckSlot();

        }
    }
    public void StartRaid()
    {
        m_currentSlotCount = 0;
        DisplayWinGold(0);
        foreach (var item in winSwords)
        {
            item.text = 0.ToString();
        }
        foreach (var item in winShields)
        {
            item.text = 0.ToString();
        }
        foreach (var item in winAmulets)
        {
            item.text = 0.ToString();
        }

     
        if(ChecnCanRaid())
        {
            for (int i = 0; i < raid_slot.Count; i++)
            {
                if (raid_slot[i].isOpened && raid_slot[i].m_currentHero != null)
                {
                    raid_slot[i].CloseUnraidPanel();
                    raid_slot[i].GetDice().CheckRandomIndex();
                    raid_slot[i].GetDice().StartRotate();
                    m_currentSlotCount++;
                }
            }
        }  
    }
    public bool ChecnCanRaid()
    {
        foreach (var item in raid_slot)
        {
            if (item.isOpened && item.m_currentHero != null)
            {
                return true;
            }
        }
        return false;
    }
    public List<Raid_UI> CheckWinPrize() => raid_slot;
    public void DisplayWinGold(long value)
    {
        foreach (var item in winGold)
        {
            item.text = ConvertText.FormatNumb(value);
        }
    }
    public void DisplayWinItems(List<Item> items)
    {
        int swords = 0;
        int shiedlds= 0;
        int amulets= 0;

        for (int i = 0; i < items.Count; i++)
        {
            switch (items[i].typeItem)
            {
                case TypeItem.Sword:
                    swords++;
                    break;
                case TypeItem.Shield:
                    shiedlds++;
                    break;
                case TypeItem.Amulet:
                    amulets++;
                    break;
            }
        }

        foreach (var item in winSwords)
        {
            item.text = swords.ToString();
        }
        foreach (var item in winShields)
        {
            item.text = shiedlds.ToString();
        }
        foreach (var item in winAmulets)
        {
            item.text = amulets.ToString();
        }
    }
    private void RotateComplete()
    {
        m_currentSlotCount--;
        if(m_currentSlotCount == 0)
        {
            GlovalEventSystem.RaidComplete(raid_slot);
        }
    }

}
