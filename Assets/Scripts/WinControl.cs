using System.Collections.Generic;
using UnityEngine;

public class WinControl : MonoBehaviour
{
    public static WinControl _instance;
    [SerializeField] private InventoryControl inventories;
    [SerializeField] private ScrollingController scrollingController;
    [SerializeField] private RayCheckingMatches rayCast;
    [SerializeField] private List<ScrollingObjects> scrollingObjects;
    private int goldWin;

    

    public List<Prize> winPrizes;// = new List<Prize>();
    
    private void Awake()
    {
        _instance = this;
    }


    void Update()
    {
        
    }
    public void CheckWinPrizes(int count_activeslots)
    {
        if(winPrizes.Count > 0)
        {
            winPrizes.Clear();
        }
        goldWin = 0;

        if (CheckFullMerge(count_activeslots))
        {
            int combo = 0;
            for (int i = 0; i < count_activeslots; i++)
            {
                combo += scrollingObjects[i].currentHero.ComboPercent;
                if (CHeckElementMerge(scrollingObjects[i].currentHero, scrollingController._currentZone))
                {
                    combo++;
                }
            }

            if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
            {
                for (int i = 0; i < count_activeslots; i++)
                {
                    winPrizes.Add(scrollingObjects[0].winPrize);
                    if (winPrizes != null)
                    {
                        inventories.WinItems(winPrizes);
                        scrollingController.DisplayWinGold(goldWin);
                        Gold.AddGold(goldWin);
                    }
                    return;
                }
            }
            else
            {
                for (int i = 0; i < combo; i++)
                {

                    winPrizes.Add(scrollingObjects[0].winPrize);
                    // Prize complete
                    if (winPrizes != null)
                    {
                        inventories.WinItems(winPrizes);
                        scrollingController.DisplayWinGold(goldWin);
                        Gold.AddGold(goldWin);
                    }
                    return;
                }
            }
           
        }
        else
        {
            if (count_activeslots < 3)
            {
                for (int i = 0; i < count_activeslots; i++)
                {
                    if (CHeckElementMerge(scrollingObjects[i].currentHero, scrollingController._currentZone))
                    {
                        if(scrollingObjects[i].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[i].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[i].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[i].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[i].winPrize, i, CHeckElementMerge(scrollingObjects[i].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[i].winPrize, i, CHeckElementMerge(scrollingObjects[i].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[i].winPrize, i, CHeckElementMerge(scrollingObjects[i].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[i].winPrize, i, CHeckElementMerge(scrollingObjects[i].currentHero, scrollingController._currentZone));
                    }
                }
            }
            if (count_activeslots >= 3 && count_activeslots < 6)
            {
                if (rayCast.FirstlLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                    {
                        for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent + 1; i++)
                        {
                            winPrizes.Add(scrollingObjects[0].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[0].winPrize);
                        }
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent + 1; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[2].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                }
                else if (!rayCast.FirstlLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[1].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[2].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                    }

                }
                // Prize complete
            }
            if (count_activeslots == 6)
            {

                if (rayCast.FirstlLineCheckMatch())
                {
                    if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[0].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                    }

                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent + 1; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[2].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                }
                else if (!rayCast.FirstlLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[1].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[2].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.SecondLineCheckMatch())
                {
                    if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[3].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[3].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[3].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[5].winPrize);
                                winPrizes.Add(scrollingObjects[5].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[5].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[5].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.SecondLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[4].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[5].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                    }

                }


            }

            if (count_activeslots == 7)
            {

                if (rayCast.FirstlLineCheckMatch())
                {
                    if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[0].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                    }

                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent + 1; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[2].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                }
                else if (!rayCast.FirstlLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[1].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[2].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.SecondLineCheckMatch())
                {
                    if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[3].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[3].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[3].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[5].winPrize);
                                winPrizes.Add(scrollingObjects[5].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[5].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[5].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.SecondLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[4].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[5].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.FirstlLineCheckMatch_vertical())
                {
                    if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[0].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[7].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.FirstlLineCheckMatch_vertical())
                {
                    if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                        else
                        {

                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.DownDiagonallyCheckMatch())
                {
                    if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[6].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[6].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[6].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[6].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[6].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[2].winPrize);
                                winPrizes.Add(scrollingObjects[2].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[2].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[2].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.DownDiagonallyCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[4].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[2].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                    }

                }
            }

            if (count_activeslots == 8)
            {

                if (rayCast.FirstlLineCheckMatch())
                {
                    if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[0].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                    }

                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent + 1; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[2].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                }
                else if (!rayCast.FirstlLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[1].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[2].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.SecondLineCheckMatch())
                {
                    if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[3].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[3].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[3].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[5].winPrize);
                                winPrizes.Add(scrollingObjects[5].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[5].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[5].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.SecondLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[4].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[5].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.FirstlLineCheckMatch_vertical())
                {
                    if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[0].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[7].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.FirstlLineCheckMatch_vertical())
                {
                    if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                        else
                        {

                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.SecondLineCheckMatch_vertical())
                {
                    if (scrollingObjects[1].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[1].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[1].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[1].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[1].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[1].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[7].winPrize);
                                winPrizes.Add(scrollingObjects[7].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[7].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[7].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.SecondLineCheckMatch_vertical())
                {
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[1].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[4].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                        else
                        {

                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[7].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[7].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[7].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[7].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));

                        }
                        else
                        {

                            CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.DownDiagonallyCheckMatch())
                {
                    if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[6].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[6].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[6].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[6].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[6].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[2].winPrize);
                                winPrizes.Add(scrollingObjects[2].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[2].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[2].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.DownDiagonallyCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[4].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[2].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                    }

                }
            }

            if (count_activeslots == 9)
            {

                if (rayCast.FirstlLineCheckMatch())
                {
                    if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                              scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[0].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                    }
                   
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent + 1; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < scrollingObjects[2].currentHero.ComboPercent; i++)
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                }
                else if (!rayCast.FirstlLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[1].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[2].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[2].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.SecondLineCheckMatch())
                {
                    if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[3].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[3].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[3].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[5].winPrize);
                                winPrizes.Add(scrollingObjects[5].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[5].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[5].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.SecondLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                        { 
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[4].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[5].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[5].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.ThirdLineCheckMatch())
                {
                    if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[6].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[6].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[6].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[6].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[6].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[7].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[7].winPrize);
                                winPrizes.Add(scrollingObjects[7].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[7].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[7].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[8].winPrize);
                                winPrizes.Add(scrollingObjects[8].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[8].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[8].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.ThirdLineCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[7].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[7].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[7].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[7].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[8].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[8].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[8].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[8].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.FirstlLineCheckMatch_vertical())
                {
                    if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[0].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[3].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[7].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.FirstlLineCheckMatch_vertical())
                {
                    if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                        else
                        {

                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[3].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[3].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[3].winPrize, 3, CHeckElementMerge(scrollingObjects[3].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                    }

                }

                if (rayCast.SecondLineCheckMatch_vertical())
                {
                    if (scrollingObjects[1].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[1].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[1].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[1].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[1].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[1].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[1].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[1].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[7].winPrize);
                                winPrizes.Add(scrollingObjects[7].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[7].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[7].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.SecondLineCheckMatch_vertical())
                {
                    if (CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[1].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[1].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[1].winPrize, 1, CHeckElementMerge(scrollingObjects[1].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[4].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                        else
                        {

                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[7].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[7].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[7].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[7].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));

                        }
                        else
                        {

                            CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[7].winPrize, 7, CHeckElementMerge(scrollingObjects[7].currentHero, scrollingController._currentZone));
                    }

                }
                                                                        

                if (rayCast.ThirdLineCheckMatch_vertical())
                {
                    if (scrollingObjects[2].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[2].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[2].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[2].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[2].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[2].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[2].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[2].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[2].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[5].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[5].winPrize);
                                winPrizes.Add(scrollingObjects[5].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[5].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[5].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[8].winPrize);
                                winPrizes.Add(scrollingObjects[8].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[8].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[8].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.ThirdLineCheckMatch_vertical())
                {
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[2].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                                CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                                CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[5].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[5].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[5].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[5].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[5].winPrize, 5, CHeckElementMerge(scrollingObjects[5].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[8].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[8].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[8].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[8].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));
                    }

                }


                if (rayCast.DownDiagonallyCheckMatch())
                {
                    if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[6].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[6].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[6].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[6].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[6].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[2].winPrize);
                                winPrizes.Add(scrollingObjects[2].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[2].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[2].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.DownDiagonallyCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[6].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[6].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[6].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[6].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[6].winPrize, 6, CHeckElementMerge(scrollingObjects[6].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[4].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[2].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[2].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[2].winPrize, 2, CHeckElementMerge(scrollingObjects[2].currentHero, scrollingController._currentZone));
                    }

                }


                if (rayCast.UpperDiagonallyCheckMatch())
                {
                    if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                             scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            winPrizes.Add(scrollingObjects[0].winPrize);
                        }
                    }
                    else
                    {
                        if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[0].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[0].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent + 1; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[4].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[4].winPrize);
                            }
                        }
                        if (CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone))
                        {
                            if (CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone))
                            {
                                winPrizes.Add(scrollingObjects[8].winPrize);
                                winPrizes.Add(scrollingObjects[8].winPrize);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < scrollingObjects[8].currentHero.ComboPercent; i++)
                            {
                                winPrizes.Add(scrollingObjects[8].winPrize);
                            }
                        }
                    }
                }
                else if (!rayCast.DownDiagonallyCheckMatch())
                {
                    if (CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[0].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[0].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[0].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[0].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));

                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[0].winPrize, 0, CHeckElementMerge(scrollingObjects[0].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[4].winPrize._Type == Type.item_egg_neutral ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_undead ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_order ||
                               scrollingObjects[4].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[4].winPrize, 4, CHeckElementMerge(scrollingObjects[4].currentHero, scrollingController._currentZone));
                    }
                    if (CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone))
                    {
                        if (scrollingObjects[8].winPrize._Type == Type.item_egg_neutral ||
                            scrollingObjects[8].winPrize._Type == Type.item_egg_undead ||
                            scrollingObjects[8].winPrize._Type == Type.item_egg_order ||
                            scrollingObjects[8].winPrize._Type == Type.item_egg_demons)
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));
                        }
                        else
                        {
                            CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));
                            CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));
                        }
                    }
                    else
                    {
                        CheckWinPrize_fromSlot(scrollingObjects[8].winPrize, 8, CHeckElementMerge(scrollingObjects[8].currentHero, scrollingController._currentZone));
                    }

                }
            }
            if (winPrizes != null)
            {
                inventories.WinItems(winPrizes);
                scrollingController.DisplayWinGold(goldWin);
                Gold.AddGold(goldWin);
            }
        }
    }
    private int WinGold(int goldLvl, Hero hero, bool elementIsMerge = false)
    {
        if(goldLvl == 1)
        {
            if(elementIsMerge)
            { var tmp = Mathf.RoundToInt(((Mathf.RoundToInt(hero.GoldProfit() / 100f) * scrollingController.elementProfit_gold) + hero.GoldProfit()) / 100f) * 75;
                return Mathf.RoundToInt(((Mathf.RoundToInt(hero.GoldProfit() / 100f) * scrollingController.elementProfit_gold) + hero.GoldProfit()) / 100f) * 75; 
            }
            else
            {
                var tmp = Mathf.RoundToInt(hero.GoldProfit() / 100f) * 75;
                return Mathf.RoundToInt(hero.GoldProfit() / 100f) * 75;
            }
        }
        else if (goldLvl == 2)
        {
            if (elementIsMerge)
            {
                var tmp = Mathf.RoundToInt(((Mathf.RoundToInt(hero.GoldProfit() / 100f) * scrollingController.elementProfit_gold) + hero.GoldProfit()) / 100f) * 100;
                return Mathf.RoundToInt(((Mathf.RoundToInt(hero.GoldProfit() / 100f) * scrollingController.elementProfit_gold) + hero.GoldProfit()) / 100f) * 100;
            }
            else
            {
                var tmp = Mathf.RoundToInt(hero.GoldProfit() / 100f) * 100;
                return Mathf.RoundToInt(hero.GoldProfit() / 100f) * 100;
            }
        }
        else if (goldLvl == 3)
        {
            if (elementIsMerge)
            {
                var tmp = Mathf.RoundToInt(((Mathf.RoundToInt(hero.GoldProfit() / 100f) * scrollingController.elementProfit_gold) + hero.GoldProfit()) / 100f) * 125;
                return Mathf.RoundToInt(((Mathf.RoundToInt(hero.GoldProfit() / 100f) * scrollingController.elementProfit_gold) + hero.GoldProfit()) / 100f) * 125;
            }
            else
            {
                var tmp = Mathf.RoundToInt(hero.GoldProfit() / 100f) * 125;
                return Mathf.RoundToInt(hero.GoldProfit() / 100f) * 125;
            }

        }
        return 0;
    }

    private bool CheckFullMerge(int count_activeslots)
    {
        switch (count_activeslots)
        {
            case 2:
                {
                    if(scrollingObjects[0].winPrize._Type == scrollingObjects[1].winPrize._Type)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            case 3:
                {
                    if (scrollingObjects[0].winPrize._Type == scrollingObjects[1].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[2].winPrize._Type)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            case 4:
                {
                    if (scrollingObjects[0].winPrize._Type == scrollingObjects[1].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[2].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[3].winPrize._Type )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            case 5:
                {
                    if (scrollingObjects[0].winPrize._Type == scrollingObjects[1].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[2].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[3].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[4].winPrize._Type)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            case 6:
                {
                    if (scrollingObjects[0].winPrize._Type == scrollingObjects[1].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[2].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[3].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[4].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[5].winPrize._Type)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            case 7:
                {
                    if (scrollingObjects[0].winPrize._Type == scrollingObjects[1].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[2].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[3].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[4].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[5].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[6].winPrize._Type)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            case 8:
                {
                    if (scrollingObjects[0].winPrize._Type == scrollingObjects[1].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[2].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[3].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[4].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[5].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[6].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[7].winPrize._Type)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            case 9:
                {
                    if (scrollingObjects[0].winPrize._Type == scrollingObjects[1].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[2].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[3].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[4].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[5].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[6].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[7].winPrize._Type &&
                        scrollingObjects[0].winPrize._Type == scrollingObjects[8].winPrize._Type)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
        }
        return false;   
    }

    private bool CHeckElementMerge(Hero hero, Zone zone)
    {

        if (hero.elementType == Hero.ElementType.Neutral && zone.ZoneElement == Zone.zoneElement.Neutral ||
           hero.elementType == Hero.ElementType.Undead && zone.ZoneElement == Zone.zoneElement.Undead ||
           hero.elementType == Hero.ElementType.Order && zone.ZoneElement == Zone.zoneElement.Order ||
           hero.elementType == Hero.ElementType.Demon && zone.ZoneElement == Zone.zoneElement.Demon)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private void CheckWinPrize_fromSlot(Prize prize, int i, bool elementIsMerge = false)
    {
        if (scrollingObjects[i].currentHero != null)
        {
            switch (scrollingObjects[i].winPrize._Type)
            {
                case Type.gold_1:
                    goldWin += WinGold(1, scrollingObjects[i].currentHero, elementIsMerge);
                    break;
                case Type.gold_2:
                    goldWin += WinGold(2, scrollingObjects[i].currentHero, elementIsMerge);
                    break;
                case Type.gold_3:
                    goldWin += WinGold(3, scrollingObjects[i].currentHero, elementIsMerge);
                    break;
                case Type.death:
                    Debug.Log("Deadt");
                    break;
                case Type.item_sword_1:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_sword_2:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_sword_3:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_shield_1:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_shield_2:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_shield_3:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_amulet_1:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_amulet_2:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_amulet_3:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_egg_neutral:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_egg_undead:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_egg_order:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
                case Type.item_egg_demons:
                    winPrizes.Add(scrollingObjects[i].winPrize);
                    break;
            }
        }
    }


}
