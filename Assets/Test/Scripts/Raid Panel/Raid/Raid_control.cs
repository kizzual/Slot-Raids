using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raid_control : MonoBehaviour
{
    [SerializeField] private Combo combo;
    [SerializeField] private List<SlotControl> allSlots;
    [SerializeField] private List<ParticleSlotControll> particleControll;
    [SerializeField] private List<Raid_UI> raid_slot; 
    [SerializeField] private List<Text> winGold;
    [SerializeField] private List<Text> winSwords;
    [SerializeField] private List<Text> winShields;
    [SerializeField] private List<Text> winAmulets;
    [SerializeField] private List<Text> nameOfLocation;
    [SerializeField] private List<Text> luckLocation;
    [SerializeField] private List<Text> unLuckLocation;
    [SerializeField] private List<Image> elementLocation;
    [SerializeField] private List<Image> item_1_icon;
    [SerializeField] private List<Image> item_2_icon;
    [SerializeField] private List<Sprite> elementLogo;
    [SerializeField] private List<GameObject> Buttons;
    [SerializeField] private List<Raid_button> raid_Buttons;
    [SerializeField] private List<GameObject> ManaButton;
    private int m_currentSlotCount = 0;
    public ParticleSlotControll m_particleSlotControll;

    public void ActivateEvent()
    {
        GlovalEventSystem.OnHeroUpgrade += UpdateHeroStats;
        GlovalEventSystem.OnSwitchLocation += Switchlocation;
        GlovalEventSystem.OnRotateComplete += RotateComplete;
    }
    public void DeActivateEvent()
    {
        GlovalEventSystem.OnHeroUpgrade -= UpdateHeroStats;
        GlovalEventSystem.OnSwitchLocation -= Switchlocation;
        GlovalEventSystem.OnRotateComplete -= RotateComplete;
    }


    private void Start()
    {
   
        foreach (var item in winSwords)
        {
            item.text = 0.ToString();
        }
        foreach (var item in winShields)
        {
            item.text = 0.ToString();
        }
        foreach (var item in winAmulets)
        {
            item.text = 0.ToString();
        }
    }
    public void CheckSlots()
    {
        foreach (var item in raid_slot)
        {
            item.OpenUnraidPanel();
            item.CheckSlot();
        }
    }
    public void UpdateHeroStats(Hero hero)
    {
        foreach (var item in raid_slot)
        {
            if (item.m_currentHero != null)
                if (item.m_currentHero == hero)
                    item.Initialise(hero);
        }
    }
    public void RemoveHero(int slotNum)
    {
        foreach (var item in raid_slot)
        {
            if(item.SlotNumber == slotNum)
            {
                item.RemoveHero();
            }
        }
    }
    public void Switchlocation(Zone zone)
    {
        StopRaid();
        foreach (var item in raid_slot)
        {
            item.SwitchBorder_andArrows();
        }
        foreach (var item in nameOfLocation)
        {
            item.text = CurrentZone.Current_Zone.nameLocation;
        }
        foreach (var item in luckLocation)
        {
            item.text = CurrentZone.Current_Zone.Luck.ToString();
        }
        foreach (var item in unLuckLocation)
        {
            item.text = CurrentZone.Current_Zone.UnLuck.ToString();
        }

        switch (CurrentZone.Current_Zone.typeElement)
        {
            case Type__Element.Neutral:
                {
                    foreach (var item in Buttons)
                    {
                        item.SetActive(false);
                    }
                    Buttons[0].SetActive(true);

                    foreach (var item in elementLocation)
                    {
                        item.sprite = elementLogo[0];
                    }
                }
                break;
            case Type__Element.Undead:
                {
                    foreach (var item in Buttons)
                    {
                        item.SetActive(false);
                    }
                    Buttons[1].SetActive(true);
                    foreach (var item in elementLocation)
                    {
                        item.sprite = elementLogo[1];
                    }
                }
                break;
            case Type__Element.Order:
                {
                    foreach (var item in Buttons)
                    {
                        item.SetActive(false);
                    }
                    Buttons[2].SetActive(true);
                    foreach (var item in elementLocation)
                    {
                        item.sprite = elementLogo[2];
                    }
                }
                break;
            case Type__Element.Demon:
                {
                    foreach (var item in Buttons)
                    {
                        item.SetActive(false);
                    }
                    Buttons[3].SetActive(true);
                    foreach (var item in elementLocation)
                    {
                        item.sprite = elementLogo[3];
                    }
                }
                break;
        }
        foreach (var item in item_1_icon)
        {
            item.sprite = CurrentZone.Current_Zone.ItemsOnZone[0].GetComponent<Image>().sprite;
        }
        foreach (var item in item_2_icon)
        {
            item.sprite = CurrentZone.Current_Zone.ItemsOnZone[1].GetComponent<Image>().sprite;
        }
        CheckSlots();
        StartRaid();
    }

    public void CheckGrade(int grade)
    {

        for (int i = 0; i < allSlots.Count; i++)
        {
            allSlots[i].DeActivateSlots();
        }
        if(grade != 0)
        {
            m_particleSlotControll = particleControll[grade - 1];
            raid_slot = allSlots[grade - 1].GetSlots();
            combo = allSlots[grade - 1].GetCombo();
            allSlots[grade - 1].ActivateSlots();
            for (int i = 0; i < raid_slot.Count; i++)
            {
                raid_slot[i].isOpened = true;
                raid_slot[i].CheckSlot();
            }
        }
    }
    public ParticleSlotControll GetParticles() => m_particleSlotControll;
    public void StopRaid()
    {
        for (int i = 0; i < raid_slot.Count; i++)
        {
            if (raid_slot[i].isOpened && raid_slot[i].m_currentHero != null)
            {
                raid_slot[i].GetDice().StopRotate();
            }
        }
        for (int i = 0; i < raid_Buttons.Count; i++)
        {
            raid_Buttons[i].ForceStopRaid();
        }

    }
    public void StartRaid()
    {
        Debug.Log("START RAID CHECK");
        m_currentSlotCount = 0;
        DisplayWinGold(0);
        foreach (var item in winSwords)
        {
            item.text = 0.ToString();
        }
        foreach (var item in winShields)
        {
            item.text = 0.ToString();
        }
        foreach (var item in winAmulets)
        {
            item.text = 0.ToString();
        }

     

        if(ChecnCanRaid())
        {
            for (int i = 0; i < raid_slot.Count; i++)
            {
                if (raid_slot[i].isOpened && raid_slot[i].m_currentHero != null)
                {
                    raid_slot[i].CloseUnraidPanel();
                    raid_slot[i].GetDice().CheckRandomIndex();
                    raid_slot[i].GetDice().StartRotate();
                    raid_slot[i].m_currentHero.GoToRaid();
                    
                    m_currentSlotCount++;
                }
            }
            for (int i = 0; i < raid_Buttons.Count; i++)
            {
                raid_Buttons[i].GoToAutoRaid();
            }
            CurrentZone.Current_Zone.GoToRaid();
            SoundControl._instance.StartRaidSound();
        }  
    }
    public void CheckOffLinePrize()
    {
        for (int i = 0; i < raid_slot.Count; i++)
        {
            if (raid_slot[i].isOpened && raid_slot[i].m_currentHero != null)
            {
                raid_slot[i].GetDice().CheckRandomIndex();
            }
        }
    }
    public bool ChecnCanRaid()
    {
        foreach (var item in raid_slot)
        {
            if (item.isOpened && item.m_currentHero != null)
            {
                return true;
            }
        }
        return false;
    }
    public List<Raid_UI> CheckWinPrize() => raid_slot;
    public void DisplayWinGold(long value)
    {
        foreach (var item in winGold)
        {
            item.text = ConvertText.FormatNumb(value);
        }
    }
    public void DisplayWinItems(List<Item> items)
    {
        int swords = 0;
        int shiedlds= 0;
        int amulets= 0;

        for (int i = 0; i < items.Count; i++)
        {
            switch (items[i].typeItem)
            {
                case TypeItem.Sword:
                    swords++;
                    break;
                case TypeItem.Shield:
                    shiedlds++;
                    break;
                case TypeItem.Amulet:
                    amulets++;
                    break;
            }
        }

        foreach (var item in winSwords)
        {
            item.text = swords.ToString();
        }
        foreach (var item in winShields)
        {
            item.text = shiedlds.ToString();
        }
        foreach (var item in winAmulets)
        {
            item.text = amulets.ToString();
        }
    }
    private void RotateComplete()
    {
        m_currentSlotCount--;
        if (m_currentSlotCount == 0)
        {
            combo.CheckCombo(raid_slot, this);
            // проверка кубов и вызов партикла если зеленый
            Debug.Log("RAIDS COMPLETE");
           
        }
    }
    public void GoldBoostActivate(int value) => combo.GoldBoostActivate(value);
    public void ItemBoostActivate(int value) => combo.ItemBoostActivate(value);
    public void GoldBoostDeActivate() => combo.GoldBoostDeActivate();
    public void ItemBoostDeActivate() => combo.ItemBoostDeActivate();

}
