using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raid_control : MonoBehaviour
{
    [SerializeField] private List<Raid_UI> raid_slot;



    public void ActivateEvent()
    {
        GlovalEventSystem.OnUpgradeTower += OnGradeTower;
        GlovalEventSystem.OnHeroUpgrade += UpdateHeroStats;
        GlovalEventSystem.OnRemoveFromSlot += RemoveHero;
        GlovalEventSystem.OnSwitchLocation += Switchlocation;

    }

    private void OnEnable()
    {
        CheckSlots();
    }
    public void CheckSlots()
    {
        foreach (var item in raid_slot)
        {
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
            raid_slot[i].isOpened = true;
            raid_slot[i].CheckSlot();

        }
    }

}
