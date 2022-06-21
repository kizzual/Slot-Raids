using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPanel : MonoBehaviour
{
    public enum ElementType
    {
        Neutral,
        Undead,
        Order,
        Demon
    }
    public ElementType elementType;

    [SerializeField] private List<HeroSlot> heroSlots;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void AddEgg()
    {
        int freeSlot = CheckFreeSlot();
        if(freeSlot != -1)
        {
            heroSlots[freeSlot].AddEgg();
        }
    }
    public void AddHero(Hero hero, int indexPosition)
    {
        heroSlots[indexPosition].AddHero(hero);
    }

    private int CheckFreeSlot()
    {
        for (int i = 0; i < heroSlots.Count; i++)
        {
            if(heroSlots[i].isEpmty)
            {
                return i;
            }
        }
        return -1;
    }

}
