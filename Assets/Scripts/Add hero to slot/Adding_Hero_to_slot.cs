using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adding_Hero_to_slot : MonoBehaviour
{
    [Header("Slots")]
    [SerializeField] private List<Slot_UI> _neutral_Slots;
    [SerializeField] private List<Slot_UI> _undead_Slots;
    [SerializeField] private List<Slot_UI> _order_Slots;
    [SerializeField] private List<Slot_UI> _demon_Slots;
    [SerializeField] private GameObject frontPanel;
    [SerializeField] private List<Raid_button> raid_buttons;
    private Raid_UI currentSlot;
    public void ActivateEvent()
    {
        GlovalEventSystem.OnAddingHeoToSlot += OpenHeroPanel;
    }


    public void OpenHeroPanel(Raid_UI slot)
    {
        currentSlot = slot;
        frontPanel.SetActive(true);
        gameObject.SetActive(true);
        foreach (var item in raid_buttons)
        {
            item.PauseRaid();
        }
    }
    public void AddHeroToSlot(Slot_UI slot_ui)
    {
        if(currentSlot.m_currentHero != null)
        {
            currentSlot.m_currentHero.currentRaidSlot = 0;
            switch (currentSlot.m_currentHero.typeElement)
            {
                case TypeElement.Neutral:
                    foreach (var item in _neutral_Slots)
                    {
                        item.Initialise();
                    }
                    break;
                case TypeElement.Undead:
                    foreach (var item in _undead_Slots)
                    {
                        item.Initialise();
                    }
                    break;
                case TypeElement.Order:
                    foreach (var item in _order_Slots)
                    {
                        item.Initialise();
                    }
                    break;
                case TypeElement.Demon:
                    foreach (var item in _demon_Slots)
                    {
                        item.Initialise();
                    }
                    break;

            }
            GlovalEventSystem.RemoveFromSlot(currentSlot.m_currentHero.currentRaidSlot);
        }
        currentSlot.Initialise(slot_ui.m_CurrentHero);
        GlovalEventSystem.TutorialSteps(7);
        slot_ui.Initialise();
    }
    public void RemoveHeroToSlot(Slot_UI slot_UI)
    {
        GlovalEventSystem.RemoveFromSlot(slot_UI.m_CurrentHero.currentRaidSlot);
        slot_UI.m_CurrentHero.currentRaidSlot = 0;
        slot_UI.Initialise();

    }
    public void ClosePanel()
    {
        frontPanel.SetActive(false);
        gameObject.SetActive(false);
        GlovalEventSystem.TutorialSteps(8);
    }

}
