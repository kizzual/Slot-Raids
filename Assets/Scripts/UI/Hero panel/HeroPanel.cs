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
    [SerializeField] Character characters;
    public List<HeroSlot> heroSlots;
    [SerializeField] private EggOpening eggOpening;
    [SerializeField] private GameObject frontPanel;
    [SerializeField] private Sprite EggImage;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void AddEgg()
    {
         int freeSlot = CheckFreeSlot();
        if (freeSlot != -1)
        {
            heroSlots[freeSlot].AddEgg(EggImage);
        }
    }
    public void OpenInventoryToCheckEggs()
    {
        int freeSlot = CheckFreeSlot();
        if(freeSlot != -1)
        {
            heroSlots[freeSlot].OpenInventoryToCheckEggs((global::ElementType)elementType, eggOpening);
        }
    }
    public void AddHero(Hero hero, int index)
    {
            heroSlots[index].AddHero(hero);       
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
    public void Open_NeutralEgg(int slotIndex)
    {
        // добавить проверку времени
        frontPanel.SetActive(true);
        eggOpening.gameObject.SetActive(true);
        eggOpening.Open_NeutralEgg(heroSlots[slotIndex]);
    }
    public void Open_UndeadEgg(int slotIndex)
    {
        // добавить проверку времени

        frontPanel.SetActive(true);
        eggOpening.gameObject.SetActive(true);
        eggOpening.Open_UndeadEgg(heroSlots[slotIndex]);
    }
    public void Open_OrderEgg(int slotIndex)
    {
        // добавить проверку времени

        frontPanel.SetActive(true);
        eggOpening.gameObject.SetActive(true);
        eggOpening.Open_OrderEgg(heroSlots[slotIndex]);
    }
    public void Open_DemonEgg(int slotIndex)
    {
        // добавить проверку времени

        frontPanel.SetActive(true);
        eggOpening.gameObject.SetActive(true);
        eggOpening.Open_DemonEgg(heroSlots[slotIndex]);
    }
}
