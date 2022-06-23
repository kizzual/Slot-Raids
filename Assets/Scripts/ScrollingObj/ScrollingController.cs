using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingController : MonoBehaviour
{
    public List<ScrollingObjects> scrollingObjects;
//    [SerializeField] private GameController game_controller;
    [SerializeField] private RayCheckingMatches _ray;
    private int _countActiveSlots;
    private bool _isScrolling = false;
    private bool _isActiveRaid;
    private Zone _currentZone;

   // public float distance;
    void Awake()
    {
        foreach (var item in GetComponentsInChildren<ScrollingObjects>())
        {
            scrollingObjects.Add(item);
        }
    }

    void Update()
    {
        if (_isActiveRaid)
        {
            if (_isScrolling)
            {
                CheckIsScrolling();
            }
            else
            {
                _ray.CheckingMatches(_countActiveSlots);
                Debug.Log("SCROLL ENDED");
                _isActiveRaid = false;
            }
        }
    }
    public void StartRaid()
    {
        if (!_isActiveRaid)
        {
            StartCoroutine(StartingRaid());
        }
    }

    public void SwitchCurrentZone(Zone zone)
    {
        if (!zone.IsClosed)
        {
            _currentZone = zone;
        }
    }

    private void CheckIsScrolling()
    {
        if(_countActiveSlots == 9)
        {
            if(!scrollingObjects[0]._scrollingIsActive &&
               !scrollingObjects[1]._scrollingIsActive &&
               !scrollingObjects[2]._scrollingIsActive &&
               !scrollingObjects[3]._scrollingIsActive &&
               !scrollingObjects[4]._scrollingIsActive &&
               !scrollingObjects[5]._scrollingIsActive &&
               !scrollingObjects[6]._scrollingIsActive &&
               !scrollingObjects[7]._scrollingIsActive &&
               !scrollingObjects[8]._scrollingIsActive )
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
               !scrollingObjects[7]._scrollingIsActive )
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
        _countActiveSlots = 0;
        for (int i = 0; i < scrollingObjects.Count; i++)
        {
            if(scrollingObjects[i].isActive)
            {
                scrollingObjects[i].StartScrolling();
                _countActiveSlots++;
                yield return new WaitForSeconds(0.1f);
            }
        }
        _isActiveRaid = true;
        _isScrolling = true;

    }
    public void FormationSlot()
    {
        for (int index = 0; index < scrollingObjects.Count; index++)
        {
            if (scrollingObjects[index].isActive)
            {
                switch (scrollingObjects[index].currentHero.Level)
                {
                    case 1:
                        {
                            List<Prize> prizeList = new List<Prize>();
                            int itemsCountPerEach = Mathf.RoundToInt((((_currentZone.ItemPercent + scrollingObjects[index].currentHero.LuckPercent) / 100f) * 30f));
                            int eggCount = _currentZone.ItemPercent + scrollingObjects[index].currentHero.LuckPercent - (itemsCountPerEach * 3);
                            for (int i = 0; i <= itemsCountPerEach; i++)
                            {
                                prizeList.Add(_currentZone.items.sword_1);
                            }
                            for (int i = 0; i <= itemsCountPerEach; i++)
                            {
                                prizeList.Add(_currentZone.items.shield_1);
                            }
                            for (int i = 0; i <= itemsCountPerEach; i++)
                            {
                                prizeList.Add(_currentZone.items.Amulet_1);
                            }
                            for (int i = 0; i < eggCount; i++)
                            {
                                prizeList.Add(_currentZone.items.Egg);
                            }
                            for (int i = 0; i < _currentZone.DeathPercent - scrollingObjects[index].currentHero.ProtectPercent; i++)
                            {
                                prizeList.Add(_currentZone.items.death);
                            }

                            int goldCOunt = 100 - prizeList.Count;
                            int gold_1 = Mathf.RoundToInt((goldCOunt / 100f) * 50f);
                            int gold_2 = Mathf.RoundToInt((goldCOunt / 100f) * 30f);
                            for (int i = 0; i <= gold_1; i++)
                            {
                                prizeList.Add(_currentZone.items.gold_1);
                            }
                            for (int i = 0; i < gold_2; i++)
                            {
                                prizeList.Add(_currentZone.items.gold_2);
                            }
                            for (int i = 0; i < 100 - (gold_1 + gold_2); i++)
                            {
                                prizeList.Add(_currentZone.items.gold_3);
                            }

                            scrollingObjects[index].GenerateListObjects(prizeList);
                            break;
                        }
                }
            }
        }
    }
}
