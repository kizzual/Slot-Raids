using System.Collections;
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

    void Awake()
    {
        raid_control.ActivateEvent();
        char_Controller.ActivateEvent();
        characteristics.ActivateEvent();
        addingItem.ActivateEvent();
        adding_Hero_to_slot.ActivateEvent();
        switchTabs.ActivateEvent();
        sell_controll.ActivateEvent();
    }


}
