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

        FrontPanel.SetActive(false);

        gameObject.SetActive(false);
        
    }

}
