using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Char_Controller char_Controller;
    [SerializeField] private Characteristics characteristics;
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private Adding_Hero_to_slot adding_Hero_to_slot;
    [SerializeField] private SwitchTabs switchTabs;
    [SerializeField] private AttentionIcon attentionIcon;
    [SerializeField] private Pause pause;
    [SerializeField] private WelcomeWindow welcomeWindow;
    [SerializeField] private CheckAttentionIcon checkAttentionIcon;
    [SerializeField] private SwitchLocation switchLocation;

    public void ActivateEvents()
    {
        raid_control.ActivateEvent();
        char_Controller.ActivateEvent();
        characteristics.ActivateEvent();  
        adding_Hero_to_slot.ActivateEvent();
        switchTabs.ActivateEvent(); 
        attentionIcon.ActivateEvent();
        checkAttentionIcon.ActivateEvent();
        switchLocation.ActivateEvent();
        pause.CheckSave();
    }

    public void DeactivateEvents()
    {
        raid_control.DeActivateEvent();
        char_Controller.DeActivateEvent();
        characteristics.DeActivateEvent();
        adding_Hero_to_slot.DeActivateEvent();
        switchTabs.DeActivateEvent();
        attentionIcon.DeActivateEvent();
        checkAttentionIcon.DeActivateEvent();
        switchLocation.DeActivateEvent();
    }

}
