using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingController : MonoBehaviour
{
    public List<ScrollingObjects> scrollingObjects;
    [SerializeField] private RayCheckingMatches _ray;
    private int _countActiveSlots;
    public bool _isScrolling = false;
    private bool _isActiveRaid;
    [HideInInspector] public Zone _currentZone;
    [SerializeField] private Zone baseZone;
    public delegate void ScrollEnded();
    public ScrollEnded _scrollEnded;
    public int elementProfit_gold;
    public int elementProfit_item;
    public int elementProfit_defence;
    [SerializeField] private List<RaidSlotInfo> raidSlotInfo;
    [SerializeField] private TowerControl towerControl;
    [SerializeField] private WinControl winControl;
    [SerializeField] private List<Text> Combo_gold_text;
    [SerializeField] private List<Sprite> BorderSPrites;
    [SerializeField] private GameController raidController;

    public float _timer;
    void Awake()
    {
     /*   foreach (var item in GetComponentsInChildren<ScrollingObjects>())
        {
            scrollingObjects.Add(item);
        }*/
        _currentZone = baseZone;
        CheckTowerUpgrade();

    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_isActiveRaid)
        {
            if (_isScrolling)
            {
                CheckIsScrolling();
            }
            else
            {
                //    _ray.CheckingMatches(_countActiveSlots);
                _scrollEnded?.Invoke();
                Debug.Log("SCROLL ENDED");
                winControl.CheckWinPrizes(_countActiveSlots );
                _isActiveRaid = false;
            }
        }
    }
    public void StartRaid()
    {
        _countActiveSlots = 0;
        
        if (!_isActiveRaid)
        {
            foreach (var item in scrollingObjects)
            {
                if (item.isActive)
                {
                    _countActiveSlots++;        
                }
            }

            DisplayWinGold(0);
            _ray.CloseCombo();
            _ray.CloseComboTExt();
            StartCoroutine(StartingRaid());

        }
    }
    public void DisplayWinGold(int goldCount)
    {
        foreach (var item in Combo_gold_text)
        {
            item.text = ConvertText.FormatNumb(goldCount);
        }
    }
    public void CheckTowerUpgrade()
    {
        int j = towerControl.GetGradeTower();
        for (int i = 0; i < raidSlotInfo.Count; i++)
        {
            if (i <= j)
            {
                if(scrollingObjects[i].currentHero != null)
                {
                    raidSlotInfo[i].ActiveHero();
                }
                else
                {
                    raidSlotInfo[i].ActiveEmpty(_currentZone);
                }
            }
            else
            {
                raidSlotInfo[i].ActiveClosed(_currentZone);
            }
        }
    }
    public void SwitchCurrentZone(Zone zone)
    {
        if (!zone.IsClosed)
        {
            _currentZone = zone;
            foreach (var item in scrollingObjects)
            {
                item.raidSlotInfo.SwitchBackground(_currentZone);
                item.raidSlotInfo.SwitchBorderImage(item.currentHero, _currentZone);
            }
        }
        raidController.SwitchButtons(_currentZone);
    }
    public void OpenSlot(int index)
    {
        raidSlotInfo[index].ActiveEmpty(_currentZone);
    }
    private void CheckIsScrolling()
    {
        if (_countActiveSlots == 9)
        {
            if (!scrollingObjects[0]._scrollingIsActive &&
               !scrollingObjects[1]._scrollingIsActive &&
               !scrollingObjects[2]._scrollingIsActive &&
               !scrollingObjects[3]._scrollingIsActive &&
               !scrollingObjects[4]._scrollingIsActive &&
               !scrollingObjects[5]._scrollingIsActive &&
               !scrollingObjects[6]._scrollingIsActive &&
               !scrollingObjects[7]._scrollingIsActive &&
               !scrollingObjects[8]._scrollingIsActive)
            {
                _isScrolling = false;
            }
        }
        if (_countActiveSlots == 8)
        {
            if (!scrollingObjects[0]._scrollingIsActive &&
               !scrollingObjects[1]._scrollingIsActive &&
               !scrollingObjects[2]._scrollingIsActive &&
               !scrollingObjects[3]._scrollingIsActive &&
               !scrollingObjects[4]._scrollingIsActive &&
               !scrollingObjects[5]._scrollingIsActive &&
               !scrollingObjects[6]._scrollingIsActive &&
               !scrollingObjects[7]._scrollingIsActive)
            {
                _isScrolling = false;
            }
        }
        if (_countActiveSlots == 7)
        {
            if (!scrollingObjects[0]._scrollingIsActive &&
               !scrollingObjects[1]._scrollingIsActive &&
               !scrollingObjects[2]._scrollingIsActive &&
               !scrollingObjects[3]._scrollingIsActive &&
               !scrollingObjects[4]._scrollingIsActive &&
               !scrollingObjects[5]._scrollingIsActive &&
               !scrollingObjects[6]._scrollingIsActive)
            {
                _isScrolling = false;
            }
        }
        if (_countActiveSlots == 6)
        {
            if (!scrollingObjects[0]._scrollingIsActive &&
               !scrollingObjects[1]._scrollingIsActive &&
               !scrollingObjects[2]._scrollingIsActive &&
               !scrollingObjects[3]._scrollingIsActive &&
               !scrollingObjects[4]._scrollingIsActive &&
               !scrollingObjects[5]._scrollingIsActive)
            {
                _isScrolling = false;
            }
        }
        if (_countActiveSlots == 5)
        {
            if (!scrollingObjects[0]._scrollingIsActive &&
               !scrollingObjects[1]._scrollingIsActive &&
               !scrollingObjects[2]._scrollingIsActive &&
               !scrollingObjects[3]._scrollingIsActive &&
               !scrollingObjects[4]._scrollingIsActive)
            {
                _isScrolling = false;
            }
        }
        if (_countActiveSlots == 4)
        {
            if (!scrollingObjects[0]._scrollingIsActive &&
               !scrollingObjects[1]._scrollingIsActive &&
               !scrollingObjects[2]._scrollingIsActive &&
               !scrollingObjects[3]._scrollingIsActive)
            {
                _isScrolling = false;
            }
        }
        if (_countActiveSlots == 3)
        {
            if (!scrollingObjects[0]._scrollingIsActive &&
               !scrollingObjects[1]._scrollingIsActive &&
               !scrollingObjects[2]._scrollingIsActive)
            {
                _isScrolling = false;
            }
        }
        if (_countActiveSlots == 2)
        {
            if (!scrollingObjects[0]._scrollingIsActive &&
               !scrollingObjects[1]._scrollingIsActive)
            {
                _isScrolling = false;
            }
        }
        if (_countActiveSlots == 1)
        {
            if (!scrollingObjects[0]._scrollingIsActive)
            {
                _isScrolling = false;
            }
        }
    }
    private IEnumerator StartingRaid()
    {
        for (int i = 0; i < scrollingObjects.Count; i++)
        {

            if (scrollingObjects[i].isActive)
            {
                scrollingObjects[i].StartScrolling();
                yield return new WaitForSeconds(0.1f);
            }
        }
        _isActiveRaid = true;
        _isScrolling = true;

    }
    private void OnEnable()
    {
        FormingSlots();
        DisplayWinGold(0);
        DisplayInfo();
    }

    public void DisplayInfo()
    {
        foreach (var item in scrollingObjects)
        {
            if(item.currentHero != null)
            {
                item.raidSlotInfo.InitialiseHero(item.currentHero);
            }
        }
    }




    public void FormingSlots()
    {

        for (int index = 0; index < scrollingObjects.Count; index++)
        {
           
            if (scrollingObjects[index].isActive && scrollingObjects[index].currentHero != null)
            {
                switch (_currentZone.zoneRank)
                {
                    case 1: 
                        scrollingObjects[index].GenerateListObjects(FormingZone_1(scrollingObjects[index].currentHero, _currentZone,index));
                        break;
                    case 2:
                        scrollingObjects[index].GenerateListObjects(FormingZone_2(scrollingObjects[index].currentHero, _currentZone, index));
                        break;
                    case 3:
                        scrollingObjects[index].GenerateListObjects(FormingZone_3(scrollingObjects[index].currentHero, _currentZone, index));
                        break;
                }
            }
        }
        foreach (var item in scrollingObjects)
        {
            item.raidSlotInfo.SwitchBorderImage(item.currentHero, _currentZone);
        }
    }
    public List<Prize> FormingZone_1(Hero hero, Zone zone, int indexSlot)
    {
        if (hero.elementType == Hero.ElementType.Neutral && zone.ZoneElement == Zone.zoneElement.Neutral ||
            hero.elementType == Hero.ElementType.Undead && zone.ZoneElement == Zone.zoneElement.Undead ||
            hero.elementType == Hero.ElementType.Order && zone.ZoneElement == Zone.zoneElement.Order ||
            hero.elementType == Hero.ElementType.Demon && zone.ZoneElement == Zone.zoneElement.Demon)
        {
            List<Prize> prizeList = new List<Prize>();
            int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item) / 100f) * 30f));
            int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item - (itemsCountPerEach * 3);
            for (int i = 0; i <= itemsCountPerEach; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.sword_1);
                }
                else if(zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.sword_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.sword_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.sword_1);
                }
            }
            for (int i = 0; i <= itemsCountPerEach; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.shield_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.shield_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.shield_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.shield_1);
                }

            }
            for (int i = 0; i <= itemsCountPerEach; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.Amulet_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.Amulet_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.Amulet_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.Amulet_1);
                }

            }
            for (int i = 0; i < eggCount; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.Egg);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.Egg);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.Egg);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.Egg);
                }
            }
            for (int i = 0; i < _currentZone.DeathPercent - (scrollingObjects[indexSlot].currentHero.ProtectPercent + elementProfit_defence); i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.death);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.death);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.death);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.death);
                }
            }

            int goldCOunt = 100 - prizeList.Count;
            int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
            int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
            for (int i = 0; i <= gold_1; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.gold_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.gold_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.gold_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.gold_1);
                }

            }
            for (int i = 0; i < gold_2; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.gold_2);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.gold_2);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.gold_2);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.gold_2);
                }
            }
            for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.gold_3);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.gold_3);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.gold_3);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.gold_3);
                }
            }

            return prizeList;
        }
        else
        {
            List<Prize> prizeList = new List<Prize>();
            int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent) / 100f) * 30f));
            int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent - (itemsCountPerEach * 3);
            for (int i = 0; i <= itemsCountPerEach; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.sword_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.sword_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.sword_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.sword_1);
                }
            }
            for (int i = 0; i <= itemsCountPerEach; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.shield_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.shield_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.shield_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.shield_1);
                }

            }
            for (int i = 0; i <= itemsCountPerEach; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.Amulet_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.Amulet_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.Amulet_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.Amulet_1);
                }

            }
            for (int i = 0; i < eggCount; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.Egg);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.Egg);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.Egg);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.Egg);
                }
            }
            for (int i = 0; i < _currentZone.DeathPercent - scrollingObjects[indexSlot].currentHero.ProtectPercent; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.death);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.death);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.death);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.death);
                }
            }

            int goldCOunt = 100 - prizeList.Count;
            int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
            int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
            for (int i = 0; i <= gold_1; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.gold_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.gold_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.gold_1);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.gold_1);
                }
            }
            for (int i = 0; i < gold_2; i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.gold_2);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.gold_2);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.gold_2);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.gold_2);
                }
            }
            for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
            {
                if (zone.ZoneElement == Zone.zoneElement.Neutral)
                {
                    prizeList.Add(_currentZone.neutralItems.gold_3);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Undead)
                {
                    prizeList.Add(_currentZone.undeadItems.gold_3);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Order)
                {
                    prizeList.Add(_currentZone.orderItems.gold_3);
                }
                else if (zone.ZoneElement == Zone.zoneElement.Demon)
                {
                    prizeList.Add(_currentZone.demonItems.gold_3);
                }
            }

            return prizeList;

        }
    }
    public List<Prize> FormingZone_2(Hero hero, Zone zone, int indexSlot)
    {
        if (hero.rank == 1)
        {
            if (hero.elementType == Hero.ElementType.Neutral && zone.ZoneElement == Zone.zoneElement.Neutral ||
             hero.elementType == Hero.ElementType.Undead && zone.ZoneElement == Zone.zoneElement.Undead ||
             hero.elementType == Hero.ElementType.Order && zone.ZoneElement == Zone.zoneElement.Order ||
             hero.elementType == Hero.ElementType.Demon && zone.ZoneElement == Zone.zoneElement.Demon)
            {
                List<Prize> prizeList = new List<Prize>();
                int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item) / 100f) * 30f));
                int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item - (itemsCountPerEach * 3);
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_1);
                    }
                }
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_1);
                    }

                }
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_1);
                    }

                }
                for (int i = 0; i < eggCount; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Egg);
                    }
                }
                for (int i = 0; i < _currentZone.DeathPercent - (scrollingObjects[indexSlot].currentHero.ProtectPercent + elementProfit_defence); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.death);
                    }
                }

                int goldCOunt = 100 - prizeList.Count;
                int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                for (int i = 0; i <= gold_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_1);
                    }

                }
                for (int i = 0; i < gold_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_2);
                    }
                }
                for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_3);
                    }
                }

                return prizeList;
            }
            else
            {
                List<Prize> prizeList = new List<Prize>();
                int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent) / 100f) * 30f));
                int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent - (itemsCountPerEach * 3);
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_1);
                    }
                }
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_1);
                    }

                }
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_1);
                    }

                }
                for (int i = 0; i < eggCount; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Egg);
                    }
                }
                for (int i = 0; i < _currentZone.DeathPercent - scrollingObjects[indexSlot].currentHero.ProtectPercent; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.death);
                    }
                }

                int goldCOunt = 100 - prizeList.Count;
                int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                for (int i = 0; i <= gold_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_1);
                    }
                }
                for (int i = 0; i < gold_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_2);
                    }
                }
                for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_3);
                    }
                }

                return prizeList;
            }
        }
        else if (hero.rank == 2)
        {
            if (hero.elementType == Hero.ElementType.Neutral && zone.ZoneElement == Zone.zoneElement.Neutral ||
                hero.elementType == Hero.ElementType.Undead && zone.ZoneElement == Zone.zoneElement.Undead ||
                hero.elementType == Hero.ElementType.Order && zone.ZoneElement == Zone.zoneElement.Order ||
                hero.elementType == Hero.ElementType.Demon && zone.ZoneElement == Zone.zoneElement.Demon)
            {
                List<Prize> prizeList = new List<Prize>();
                int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item) / 100f) * 30f));
                int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item - (itemsCountPerEach * 3);
                int lvlItems_2 = Mathf.RoundToInt(((itemsCountPerEach / 100f) * 35f));
                int lvlItems_1 = itemsCountPerEach - lvlItems_2;

                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_1);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_1);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_1);
                    }
                }
                for (int i = 0; i < eggCount; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Egg);
                    }
                }
                for (int i = 0; i < _currentZone.DeathPercent - (scrollingObjects[indexSlot].currentHero.ProtectPercent + elementProfit_defence); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.death);
                    }
                }

                int goldCOunt = 100 - prizeList.Count;
                int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                for (int i = 0; i <= gold_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_1);
                    }
                }
                for (int i = 0; i < gold_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_2);
                    }
                }
                for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_3);
                    }
                }

                return prizeList;
            }
            else
            {
                List<Prize> prizeList = new List<Prize>();
                int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent) / 100f) * 30f));
                int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent - (itemsCountPerEach * 3);
                int lvlItems_2 = Mathf.RoundToInt(((itemsCountPerEach / 100f) * 35f));
                int lvlItems_1 = itemsCountPerEach - lvlItems_2;

                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_1);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_1);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_1);
                    }
                }
                for (int i = 0; i < eggCount; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Egg);
                    }
                }
                for (int i = 0; i < _currentZone.DeathPercent - scrollingObjects[indexSlot].currentHero.ProtectPercent; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.death);
                    }
                }

                int goldCOunt = 100 - prizeList.Count;
                int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                for (int i = 0; i <= gold_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_1);
                    }
                }
                for (int i = 0; i < gold_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_2);
                    }
                }
                for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_3);
                    }
                }

                return prizeList;

            }
        }
        return null;
    }
    public List<Prize> FormingZone_3(Hero hero, Zone zone, int indexSlot)
    {
        if (hero.rank == 1)
        {
            if (hero.elementType == Hero.ElementType.Neutral && zone.ZoneElement == Zone.zoneElement.Neutral ||
             hero.elementType == Hero.ElementType.Undead && zone.ZoneElement == Zone.zoneElement.Undead ||
             hero.elementType == Hero.ElementType.Order && zone.ZoneElement == Zone.zoneElement.Order ||
             hero.elementType == Hero.ElementType.Demon && zone.ZoneElement == Zone.zoneElement.Demon)
            {
                List<Prize> prizeList = new List<Prize>();
                int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item) / 100f) * 30f));
                int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item - (itemsCountPerEach * 3);
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_1);
                    }
                }
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_1);
                    }

                }
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_1);
                    }

                }
                for (int i = 0; i < eggCount; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Egg);
                    }
                }
                for (int i = 0; i < _currentZone.DeathPercent - (scrollingObjects[indexSlot].currentHero.ProtectPercent + elementProfit_defence); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.death);
                    }
                }

                int goldCOunt = 100 - prizeList.Count;
                int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                for (int i = 0; i <= gold_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_1);
                    }

                }
                for (int i = 0; i < gold_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_2);
                    }
                }
                for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_3);
                    }
                }

                return prizeList;
            }
            else
            {
                List<Prize> prizeList = new List<Prize>();
                int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent) / 100f) * 30f));
                int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent - (itemsCountPerEach * 3);
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_1);
                    }
                }
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_1);
                    }

                }
                for (int i = 0; i <= itemsCountPerEach; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_1);
                    }

                }
                for (int i = 0; i < eggCount; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Egg);
                    }
                }
                for (int i = 0; i < _currentZone.DeathPercent - scrollingObjects[indexSlot].currentHero.ProtectPercent; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.death);
                    }
                }

                int goldCOunt = 100 - prizeList.Count;
                int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                for (int i = 0; i <= gold_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_1);
                    }
                }
                for (int i = 0; i < gold_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_2);
                    }
                }
                for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_3);
                    }
                }

                return prizeList;
            }
        }
        else if (hero.rank == 2)
        {
            if (hero.elementType == Hero.ElementType.Neutral && zone.ZoneElement == Zone.zoneElement.Neutral ||
                hero.elementType == Hero.ElementType.Undead && zone.ZoneElement == Zone.zoneElement.Undead ||
                hero.elementType == Hero.ElementType.Order && zone.ZoneElement == Zone.zoneElement.Order ||
                hero.elementType == Hero.ElementType.Demon && zone.ZoneElement == Zone.zoneElement.Demon)
            {
                List<Prize> prizeList = new List<Prize>();
                int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item) / 100f) * 30f));
                int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item - (itemsCountPerEach * 3);
                int lvlItems_2 = Mathf.RoundToInt(((itemsCountPerEach / 100f) * 35f));
                int lvlItems_1 = itemsCountPerEach - lvlItems_2;

                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_1);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_1);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_1);
                    }
                }
                for (int i = 0; i < eggCount; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Egg);
                    }
                }
                for (int i = 0; i < _currentZone.DeathPercent - (scrollingObjects[indexSlot].currentHero.ProtectPercent + elementProfit_defence); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.death);
                    }
                }

                int goldCOunt = 100 - prizeList.Count;
                int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                for (int i = 0; i <= gold_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_1);
                    }
                }
                for (int i = 0; i < gold_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_2);
                    }
                }
                for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_3);
                    }
                }

                return prizeList;
            }
            else
            {
                List<Prize> prizeList = new List<Prize>();
                int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent) / 100f) * 30f));
                int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent - (itemsCountPerEach * 3);
                int lvlItems_2 = Mathf.RoundToInt(((itemsCountPerEach / 100f) * 35f));
                int lvlItems_1 = itemsCountPerEach - lvlItems_2;

                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_1);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_1);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_1);
                    }
                }
                for (int i = 0; i < eggCount; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Egg);
                    }
                }
                for (int i = 0; i < _currentZone.DeathPercent - scrollingObjects[indexSlot].currentHero.ProtectPercent; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.death);
                    }
                }

                int goldCOunt = 100 - prizeList.Count;
                int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                for (int i = 0; i <= gold_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_1);
                    }
                }
                for (int i = 0; i < gold_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_2);
                    }
                }
                for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_3);
                    }
                }

                return prizeList;

            }
        }
        else if (hero.rank == 3)
        {
            if (hero.elementType == Hero.ElementType.Neutral && zone.ZoneElement == Zone.zoneElement.Neutral ||
                  hero.elementType == Hero.ElementType.Undead && zone.ZoneElement == Zone.zoneElement.Undead ||
                  hero.elementType == Hero.ElementType.Order && zone.ZoneElement == Zone.zoneElement.Order ||
                  hero.elementType == Hero.ElementType.Demon && zone.ZoneElement == Zone.zoneElement.Demon)
            {
                List<Prize> prizeList = new List<Prize>();
                int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item) / 100f) * 30f));
                int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent + elementProfit_item - (itemsCountPerEach * 3);
                int lvlItems_3 = Mathf.RoundToInt(((itemsCountPerEach / 100f) * 20f));
                int lvlItems_2 = Mathf.RoundToInt(((itemsCountPerEach / 100f) * 35f));
                int lvlItems_1 = itemsCountPerEach - (lvlItems_2 + lvlItems_3);

                for (int i = 0; i <= lvlItems_3; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_3);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_1);
                    }
                }

                for (int i = 0; i <= lvlItems_3; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_3);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_1);
                    }
                }

                for (int i = 0; i <= lvlItems_3; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_3);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_1);
                    }
                }
                for (int i = 0; i < eggCount; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Egg);
                    }
                }
                for (int i = 0; i < _currentZone.DeathPercent - (scrollingObjects[indexSlot].currentHero.ProtectPercent + elementProfit_defence); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.death);
                    }
                }

                int goldCOunt = 100 - prizeList.Count;
                int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                for (int i = 0; i <= gold_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_1);
                    }
                }
                for (int i = 0; i < gold_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_2);
                    }
                }
                for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_3);
                    }
                }

                return prizeList;
            }
            else
            {
                List<Prize> prizeList = new List<Prize>();
                int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent) / 100f) * 30f));
                int eggCount = _currentZone.ItemPercent + scrollingObjects[indexSlot].currentHero.LuckPercent - (itemsCountPerEach * 3);
                int lvlItems_3 = Mathf.RoundToInt(((itemsCountPerEach / 100f) * 20f));
                int lvlItems_2 = Mathf.RoundToInt(((itemsCountPerEach / 100f) * 35f));
                int lvlItems_1 = itemsCountPerEach - (lvlItems_2 + lvlItems_3);
            

                for (int i = 0; i <= lvlItems_3; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_3);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.sword_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.sword_1);
                    }
                }

                for (int i = 0; i <= lvlItems_3; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_3);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.shield_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.shield_1);
                    }
                }

                for (int i = 0; i <= lvlItems_3; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_3);
                    }
                }
                for (int i = 0; i <= lvlItems_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_2);
                    }
                }
                for (int i = 0; i <= lvlItems_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Amulet_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Amulet_1);
                    }
                }
                for (int i = 0; i < eggCount; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.Egg);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.Egg);
                    }
                }
                for (int i = 0; i < _currentZone.DeathPercent - scrollingObjects[indexSlot].currentHero.ProtectPercent; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.death);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.death);
                    }
                }

                int goldCOunt = 100 - prizeList.Count;
                int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                for (int i = 0; i <= gold_1; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_1);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_1);
                    }
                }
                for (int i = 0; i < gold_2; i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_2);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_2);
                    }
                }
                for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                {
                    if (zone.ZoneElement == Zone.zoneElement.Neutral)
                    {
                        prizeList.Add(_currentZone.neutralItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Undead)
                    {
                        prizeList.Add(_currentZone.undeadItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Order)
                    {
                        prizeList.Add(_currentZone.orderItems.gold_3);
                    }
                    else if (zone.ZoneElement == Zone.zoneElement.Demon)
                    {
                        prizeList.Add(_currentZone.demonItems.gold_3);
                    }
                }

                return prizeList;

            }

        }




        return null;
    }
}
