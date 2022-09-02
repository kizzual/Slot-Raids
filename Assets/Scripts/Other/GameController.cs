using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Char_Controller char_Controller;
    [SerializeField] private Characteristics characteristics;
    [SerializeField] private AddingItem addingItem;
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private Adding_Hero_to_slot adding_Hero_to_slot;
    [SerializeField] private SwitchTabs switchTabs;
    [SerializeField] private Sell_controll sell_controll;
    [SerializeField] private Inventory_controll inventory_controll;
    [SerializeField] private CheckCombo checkCombo;
    [SerializeField] private List<Tower_quest> tower_quest;
    [SerializeField] private Boost_Controll boost_Controll;
    [SerializeField] private AttentionIcon attentionIcon;
    [SerializeField] private Tutorial tutorial;
    [SerializeField] private Pause pause;
    [SerializeField] private WelcomeWindow welcomeWindow;
    [SerializeField] private NewTutorialSystem newTutorialSystem;
    [SerializeField] private CheckAttentionIcon checkAttentionIcon;

    void Awake()
    {
        raid_control.ActivateEvent();
        char_Controller.ActivateEvent();
        characteristics.ActivateEvent();
        addingItem.ActivateEvent();
        adding_Hero_to_slot.ActivateEvent();
        switchTabs.ActivateEvent();
        sell_controll.ActivateEvent();
        inventory_controll.ActivateEvent();
        checkCombo.ActivateEvent();
        foreach (var item in tower_quest)
        {
            item.ActivateEvent();
        }
        boost_Controll.ActivateEvent();
        attentionIcon.ActivateEvent();
        tutorial.ActivateEvent();
        checkAttentionIcon.ActivateEvent();
        pause.CheckSave();
        welcomeWindow.Initialise();
        newTutorialSystem.Firstinitialise();

    }
    public void DeactiveEvents()
    {
        raid_control.DeActivateEvent();
        char_Controller.DeActivateEvent();
        characteristics.DeActivateEvent();
        addingItem.DeActivateEvent();
        adding_Hero_to_slot.DeActivateEvent();
        switchTabs.DeActivateEvent();
        sell_controll.DeActivateEvent();
        inventory_controll.DeActivateEvent();
        checkCombo.DeActivateEvent();
        foreach (var item in tower_quest)
        {
            item.DeActivateEvent();
        }
        boost_Controll.DeActivateEvent();
        attentionIcon.DeActivateEvent();
        tutorial.DeActivateEvent();
        checkAttentionIcon.DeActivateEvent();
    }

}
