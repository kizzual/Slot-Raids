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
    [SerializeField] private Tower_quest tower_quest;
    [SerializeField] private Boost_Controll boost_Controll;

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
        tower_quest.ActivateEvent();
        boost_Controll.ActivateEvent();
    }


}
