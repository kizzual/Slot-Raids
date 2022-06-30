using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoosePanel : MonoBehaviour
{
    [SerializeField] private List<ChooseSlot> neutral_chooseSlots;
    [SerializeField] private List<ChooseSlot> undead_chooseSlots;
    [SerializeField] private List<ChooseSlot> uorder_chooseSlots;
    [SerializeField] private List<ChooseSlot> demon_chooseSlots;
    [SerializeField] private HeroPanel neutral_heroPanel;
    [SerializeField] private HeroPanel undead_heroPanel;
    [SerializeField] private HeroPanel order_heroPanel;
    [SerializeField] private HeroPanel demon_heroPanel;
    [SerializeField] private ScrollingController scrollingController;
    [SerializeField] private GameObject FrontPanel;
    private ScrollingObjects _currentSlot;

    public void Initialise()
    {

    }
    private void OnEnable()
    {
        for (int i = 0; i < neutral_chooseSlots.Count; i++)
        {
            if (neutral_heroPanel.heroSlots[i].currentHero.ID != -1)
            {
                bool isFree = true;
                foreach (var item in scrollingController.scrollingObjects)
                {
                    if (neutral_heroPanel.heroSlots[i].currentHero == item.currentHero) // возможно ID
                    {
                        isFree = false;
                    }
                }
                neutral_chooseSlots[i].Initialise(neutral_heroPanel.heroSlots[i].currentHero, isFree, scrollingController, _currentSlot);
            }
        }
        for (int i = 0; i < undead_chooseSlots.Count; i++)
        {
            if (undead_heroPanel.heroSlots[i].currentHero.ID != -1)
            {
                bool isFree = true;
                foreach (var item in scrollingController.scrollingObjects)
                {
                    if (undead_heroPanel.heroSlots[i].currentHero == item.currentHero) // возможно ID
                    {
                        isFree = false;
                    }
                }
                undead_chooseSlots[i].Initialise(undead_heroPanel.heroSlots[i].currentHero, isFree, scrollingController, _currentSlot);
            }
        }
        for (int i = 0; i < uorder_chooseSlots.Count; i++)
        {
            if (order_heroPanel.heroSlots[i].currentHero.ID != -1)
            {
                bool isFree = true;
                foreach (var item in scrollingController.scrollingObjects)
                {
                    if (order_heroPanel.heroSlots[i].currentHero == item.currentHero) // возможно ID
                    {
                        isFree = false;
                    }
                }
                uorder_chooseSlots[i].Initialise(order_heroPanel.heroSlots[i].currentHero, isFree, scrollingController, _currentSlot);
            }
        }
        for (int i = 0; i < demon_chooseSlots.Count; i++)
        {
            if (demon_heroPanel.heroSlots[i].currentHero.ID != -1)
            {
                bool isFree = true;
                foreach (var item in scrollingController.scrollingObjects)
                {
                    if (demon_heroPanel.heroSlots[i].currentHero == item.currentHero) // возможно ID
                    {
                        isFree = false;
                    }
                }
                demon_chooseSlots[i].Initialise(demon_heroPanel.heroSlots[i].currentHero, isFree, scrollingController, _currentSlot);
            }

        }
        
    }

    public void OpenChoosePanel(ScrollingObjects scrollingObjects)
    {
        FrontPanel.SetActive(true);
        gameObject.SetActive(true);
        _currentSlot = scrollingObjects;
    }
    public void AddHeroToSlot(ChooseSlot slot)
    {
        _currentSlot.AddCurrentHero(slot.currentHero);
        scrollingController.FormingSlots();
        FrontPanel.SetActive(false);

        gameObject.SetActive(false);
        
    }
    public void CloseChoosePanel()
    {
        FrontPanel.SetActive(false);
        gameObject.SetActive(false);
    }

}
