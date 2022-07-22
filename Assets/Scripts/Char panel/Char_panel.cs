using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Char_panel : MonoBehaviour
{
    public enum ElementType
    {
        Neutral,
        Undead,
        Order,
        Demon
    }
    [Header("Element type")]
    public ElementType elementType;

    [SerializeField] private List<Char_slot> _charSlots;

    public void ChangeHeroStats(Hero hero)
    {
        foreach (var item in _charSlots)
        {
            if (item.m_CurrentHero == hero)
            {
                item.DisplayHeroInfirmation();
                return;
            }
        }
    }

    public Char_slot FindFirstEmptySlot()
    {
        for (int i = 0; i < _charSlots.Count; i++)
        {
            if (_charSlots[i].m_IsEmpty)
                return _charSlots[i];
        }
        return null;
    }

}

