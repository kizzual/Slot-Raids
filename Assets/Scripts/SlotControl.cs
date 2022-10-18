using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotControl : MonoBehaviour
{
    public List<Raid_UI> Slots;
    public Combo combo;
    public enum LvlType
    {
        first,
        second,
        third,
        fourth,
        fifth,
        sixth,
        seventh,
        eighth,
        ninth
    }
    public LvlType lvlType;

    public void ActivateSlots()
    {
        gameObject.SetActive(true);

    }

    public List<Raid_UI> GetSlots() => Slots;
    public Combo GetCombo() => combo;
    public void DeActivateSlots()
    {
        gameObject.SetActive(false);
    }
}
