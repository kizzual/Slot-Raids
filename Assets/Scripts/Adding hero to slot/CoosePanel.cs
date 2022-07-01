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
    public SwitchPanel switchPanel;

    public void Initialise()
    {

    }
    private void OnEnable()
    {
        CheckHeroInSlots();



    }
    public void CheckHeroInSlots()
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
                Debug.Log(isFree);
            }
            else
            {
                neutral_chooseSlots[i].isEmpty = true;
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
            else
            {
                undead_chooseSlots[i].isEmpty = true;
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
            else
            {
                uorder_chooseSlots[i].isEmpty = true;
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
            else
            {
                demon_chooseSlots[i].isEmpty = true;
            }

        }
        if (FindEmpetySlot(neutral_chooseSlots) != -1)
        {
            Debug.Log("2");

            neutral_chooseSlots[FindEmpetySlot(neutral_chooseSlots)].ShowClosedPanel_txt();
        }
        if (FindEmpetySlot(undead_chooseSlots) != -1)
        {
            undead_chooseSlots[FindEmpetySlot(undead_chooseSlots)].ShowClosedPanel_txt();
        }
        if (FindEmpetySlot(uorder_chooseSlots) != -1)
        {
            uorder_chooseSlots[FindEmpetySlot(uorder_chooseSlots)].ShowClosedPanel_txt();
        }
        if (FindEmpetySlot(demon_chooseSlots) != -1)
        {
            demon_chooseSlots[FindEmpetySlot(demon_chooseSlots)].ShowClosedPanel_txt();
        }


    }
    private int FindEmpetySlot(List<ChooseSlot> panels)
    {
        Debug.Log("panels 0 = " + panels[0].isEmpty);
        for (int i = 0; i < panels.Count; i++)
        {
            if(panels[i].isEmpty)
            {
                return i;
            }
        }
        return -1;
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
    public void FreeHero()
    {
        _currentSlot.currentHero = null;
        CheckHeroInSlots();

    }

    public void OpenCharPanel(int index)
    {
        gameObject.SetActive(false);
        FrontPanel.SetActive(false);
        switchPanel.ActivateCurrentButton(1);
        if(index == 0 )
        {
            neutral_heroPanel.gameObject.SetActive(true);
            undead_heroPanel.gameObject.SetActive(false);
            order_heroPanel.gameObject.SetActive(false);
            demon_heroPanel.gameObject.SetActive(false);
        }
        else if(index == 1)
        {
            neutral_heroPanel.gameObject.SetActive(false);
            undead_heroPanel.gameObject.SetActive(true);
            order_heroPanel.gameObject.SetActive(false);
            demon_heroPanel.gameObject.SetActive(false);
        }
        else if (index == 2)
        {
            neutral_heroPanel.gameObject.SetActive(false);
            undead_heroPanel.gameObject.SetActive(false);
            order_heroPanel.gameObject.SetActive(true);
            demon_heroPanel.gameObject.SetActive(false);
        }
        else if (index == 1)
        {
            neutral_heroPanel.gameObject.SetActive(false);
            undead_heroPanel.gameObject.SetActive(false);
            order_heroPanel.gameObject.SetActive(false);
            demon_heroPanel.gameObject.SetActive(true);
        }
    }

}
