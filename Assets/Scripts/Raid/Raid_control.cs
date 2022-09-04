using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raid_control : MonoBehaviour
{
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
    [SerializeField] private List<GameObject> ManaButton;
    private int m_currentSlotCount = 0;


    public void ActivateEvent()
    {
        GlovalEventSystem.OnUpgradeTower += OnGradeTower;
        GlovalEventSystem.OnHeroUpgrade += UpdateHeroStats;
        GlovalEventSystem.OnRemoveFromSlot += RemoveHero;
        GlovalEventSystem.OnSwitchLocation += Switchlocation;
        GlovalEventSystem.OnWinGold += DisplayWinGold;
        GlovalEventSystem.OnWinItems += DisplayWinItems;
        GlovalEventSystem.OnRotateComplete += RotateComplete;
    }
    public void DeActivateEvent()
    {
        GlovalEventSystem.OnUpgradeTower -= OnGradeTower;
        GlovalEventSystem.OnHeroUpgrade -= UpdateHeroStats;
        GlovalEventSystem.OnRemoveFromSlot -= RemoveHero;
        GlovalEventSystem.OnSwitchLocation -= Switchlocation;
        GlovalEventSystem.OnWinGold -= DisplayWinGold;
        GlovalEventSystem.OnWinItems -= DisplayWinItems;
        GlovalEventSystem.OnRotateComplete -= RotateComplete;
    }

    private void Start()
    {
        /*  CheckSlots();
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
          foreach (var item in item_1_icon)
          {
              item.sprite = CurrentZone.Current_Zone.ItemsOnZone[0].GetComponent<Image>().sprite;
          }
          foreach (var item in item_2_icon)
          {
              item.sprite = CurrentZone.Current_Zone.ItemsOnZone[1].GetComponent<Image>().sprite;
          }
          switch (CurrentZone.Current_Zone.typeElement)
          {
              case Type__Element.Neutral:
                  foreach (var item in elementLocation)
                  {
                      item.sprite = elementLogo[0];
                  }
                  break;
              case Type__Element.Undead:
                  foreach (var item in elementLocation)
                  {
                      item.sprite = elementLogo[1];
                  }
                  break;
              case Type__Element.Order:
                  foreach (var item in elementLocation)
                  {
                      item.sprite = elementLogo[2];
                  }
                  break;
              case Type__Element.Demon:
                  foreach (var item in elementLocation)
                  {
                      item.sprite = elementLogo[3];
                  }
                  break;
          }*/
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
    }

    private void OnGradeTower(int gradeNumber)
    {
        for (int i = 0; i < gradeNumber; i++)
        {
            Debug.Log("GRADE");
            raid_slot[i].isOpened = true;
            raid_slot[i].CheckSlot();

        }
    }
    public void CheckGrade(int grade)
    {
        for (int i = 0; i < grade; i++)
        {
            raid_slot[i].isOpened = true;
        }
    }
    public void StartRaid()
    {
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
            CurrentZone.Current_Zone.GoToRaid();
            GlovalEventSystem.RaidStart();
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
            Debug.Log("RAIDS COMPLETE");
            GlovalEventSystem.RaidComplete(raid_slot);
           
        }
    }

}
