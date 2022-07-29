using System.Collections.Generic;
using UnityEngine;

public class CheckCombo : MonoBehaviour
{
    [SerializeField] private GameObject firstLine_horizontal;
    [SerializeField] private GameObject firstLine_vertical;
    [SerializeField] private GameObject secondLine_horizontal;
    [SerializeField] private GameObject secondLine_vertical;
    [SerializeField] private GameObject thirdLine_horizontal;
    [SerializeField] private GameObject thirdLine_vertical;
    [SerializeField] private GameObject diagonallyLine_toDown;
    [SerializeField] private GameObject diagonallyLine_toUp;
    private int activeSlots = 0;
    private int m_combo= 0;
    private int m_unluck= 0;
    private float m_timer = 0;
    private bool m_isCombo;
    private int m_boostGold = 1;
    private int m_boostItem = 1;
    public void ActivateEvent()
    {
        GlovalEventSystem.OnRaidComplete += Combo;
        GlovalEventSystem.OnGoldBoostActivate += GoldBoostActivate;
        GlovalEventSystem.OnGoldBoostDeActivate += GoldBoostDeActivate;
        GlovalEventSystem.OnItemBoostActivate += ItemBoostActivate;
        GlovalEventSystem.OnItemBoostDeActivate += ItemBoostDeActivate;
        GlovalEventSystem.OnRaidStart += CloseCombo;
    }

    private void FixedUpdate()
    {
        if(m_isCombo)
        {
            m_timer += Time.fixedDeltaTime;
            if(m_timer >= 2f)
            {
                m_isCombo = false;
                firstLine_horizontal.SetActive(false);
                firstLine_vertical.SetActive(false);
                secondLine_horizontal.SetActive(false);
                secondLine_vertical.SetActive(false);
                thirdLine_horizontal.SetActive(false);
                thirdLine_vertical.SetActive(false);
                diagonallyLine_toDown.SetActive(false);
                diagonallyLine_toUp.SetActive(false);
                m_timer = 0;
            }
        }
    }
    public void Combo(List<Raid_UI> slots)
    {
        firstLine_horizontal.SetActive(false);
        firstLine_vertical.SetActive(false);
        secondLine_horizontal.SetActive(false);
        secondLine_vertical.SetActive(false);
        thirdLine_horizontal.SetActive(false);
        thirdLine_vertical.SetActive(false);
        diagonallyLine_toDown.SetActive(false);
        diagonallyLine_toUp.SetActive(false);


        List<Item> winItems = new List<Item>();
        if (winItems.Count > 0)
            winItems.Clear();
        long winGold = 0;
        bool isFullCombo = false;
        m_combo = 0;
        m_unluck = 0;



        /*        
                if(CheckFullGold(slots))
                {
                    isFullCombo = true;
                    // проверить кто сколько заработал на основе activeSlots
                    // суммировать и умножить на комбо
                    // комбо голды среди всех слотов
                    // добавить голд
                }
                else if(CheckFullItem(slots))
                {
                    isFullCombo = true;
                    // проверить јйтемы которые выбили на основе activeSlots
                    // суммировать и умножить на комбо
                    // комбо айтемов среди всех слотов
                    // добавить айтемы в список и добавить в инвентарь
                }*/
        if (!isFullCombo)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if(slots[i].isOpened && slots[i].m_currentHero != null)
                {
                    if (slots[i].GetDice().prize == DiceControll.Prize.Item)
                    {
                        for (int j = 0; j < m_boostItem; j++)
                        {
                            winItems.Add(slots[i].GetDice().winItem);
                        }
                        winGold += slots[i].m_currentHero.GetGoldProfit();
                       
                    }
                    else if (slots[i].GetDice().prize == DiceControll.Prize.Gold)
                        winGold += slots[i].m_currentHero.GetGoldProfit();
                    else if (slots[i].GetDice().prize == DiceControll.Prize.Death)
                        m_unluck++;
                }
            }
            // проверка комбинаций
            if (CheckLineCombo(slots[0], slots[1], slots[2]))
            {
                int combo = slots[0].m_currentHero.GetCombo() + slots[1].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[1].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                totalComgoGold *= combo;
                winGold += totalComgoGold;
                winItems.Add(slots[0].GetDice().winItem);
                winItems.Add(slots[1].GetDice().winItem);
                winItems.Add(slots[2].GetDice().winItem);
                firstLine_horizontal.SetActive(true);
                m_isCombo = true;
                m_combo++;
            }
            if (CheckLineCombo(slots[3], slots[4], slots[5]))
            {
                int combo = slots[3].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo();
                long totalComgoGold = slots[3].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit();
                totalComgoGold *= combo;
                winGold += totalComgoGold;
                winItems.Add(slots[3].GetDice().winItem);
                winItems.Add(slots[4].GetDice().winItem);
                winItems.Add(slots[5].GetDice().winItem);
                secondLine_horizontal.SetActive(true);
                m_isCombo = true;
                m_combo++;
            }
            if (CheckLineCombo(slots[6], slots[7], slots[8]))
            {
                int combo = slots[6].m_currentHero.GetCombo() + slots[7].m_currentHero.GetCombo() + slots[8].m_currentHero.GetCombo();
                long totalComgoGold = slots[6].m_currentHero.GetGoldProfit() + slots[7].m_currentHero.GetGoldProfit() + slots[8].m_currentHero.GetGoldProfit();
                totalComgoGold *= combo;
                winGold += totalComgoGold;
                winItems.Add(slots[6].GetDice().winItem);
                winItems.Add(slots[7].GetDice().winItem);
                winItems.Add(slots[8].GetDice().winItem);
                thirdLine_horizontal.SetActive(true);
                m_isCombo = true;
                m_combo++;
            }
            if (CheckLineCombo(slots[0], slots[3], slots[6]))
            {
                int combo = slots[0].m_currentHero.GetCombo() + slots[3].m_currentHero.GetCombo() + slots[6].m_currentHero.GetCombo();
                long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[3].m_currentHero.GetGoldProfit() + slots[6].m_currentHero.GetGoldProfit();
                totalComgoGold *= combo;
                winGold += totalComgoGold;
                winItems.Add(slots[0].GetDice().winItem);
                winItems.Add(slots[3].GetDice().winItem);
                winItems.Add(slots[6].GetDice().winItem);
                firstLine_vertical.SetActive(true);
                m_isCombo = true;
                m_combo++;
            }
            if (CheckLineCombo(slots[1], slots[5], slots[7]))
            {
                int combo = slots[1].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo() + slots[7].m_currentHero.GetCombo();
                long totalComgoGold = slots[1].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit() + slots[7].m_currentHero.GetGoldProfit();
                totalComgoGold *= combo;
                winGold += totalComgoGold;
                winItems.Add(slots[1].GetDice().winItem);
                winItems.Add(slots[5].GetDice().winItem);
                winItems.Add(slots[7].GetDice().winItem);
                secondLine_vertical.SetActive(true);
                m_isCombo = true;
                m_combo++;
            }
            if (CheckLineCombo(slots[2], slots[5], slots[8]))
            {
                int combo = slots[2].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo() + slots[8].m_currentHero.GetCombo();
                long totalComgoGold = slots[2].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit() + slots[8].m_currentHero.GetGoldProfit();
                totalComgoGold *= combo;
                winGold += totalComgoGold;
                winItems.Add(slots[2].GetDice().winItem);
                winItems.Add(slots[5].GetDice().winItem);
                winItems.Add(slots[8].GetDice().winItem);
                thirdLine_vertical.SetActive(true);
                m_isCombo = true;
                m_combo++;
            }
            if (CheckLineCombo(slots[0], slots[4], slots[8]))
            {
                int combo = slots[0].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[8].m_currentHero.GetCombo();
                long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[8].m_currentHero.GetGoldProfit();
                totalComgoGold *= combo;
                winGold += totalComgoGold;
                winItems.Add(slots[0].GetDice().winItem);
                winItems.Add(slots[4].GetDice().winItem);
                winItems.Add(slots[8].GetDice().winItem);
                diagonallyLine_toDown.SetActive(true);
                m_isCombo = true;
                m_combo++;
            }
            if (CheckLineCombo(slots[2], slots[4], slots[6]))
            {
                int combo = slots[2].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[6].m_currentHero.GetCombo();
                long totalComgoGold = slots[2].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[6].m_currentHero.GetGoldProfit();
                totalComgoGold *= combo;
                winGold += totalComgoGold;
                winItems.Add(slots[2].GetDice().winItem);
                winItems.Add(slots[4].GetDice().winItem);
                winItems.Add(slots[6].GetDice().winItem);
                diagonallyLine_toUp.SetActive(true);
                m_isCombo = true;
                m_combo++;
            }

            // выдача призов
            
            Gold.AddGold(winGold * m_boostGold);
            GlovalEventSystem.WinGold(winGold * m_boostGold);
            ItemsAwarding(winItems);
            GlovalEventSystem.CheckAchievement(winItems, winGold * m_boostGold, m_combo, m_unluck);
        }
    }

    private bool CheckFullGold(List<Raid_UI> slots)
    {
        activeSlots = 0;
        bool combo = false;
        for (int i = 0; i < slots.Count; i++)
        {
            activeSlots++;

            if (slots[i].GetDice().prize == DiceControll.Prize.Gold)
                combo = true;
            else
            {
                combo = false;
                return combo;
            }
        }
        return combo;
    }
    private bool CheckFullItem(List<Raid_UI> slots)
    {
        activeSlots = 0;
        bool combo = false;
        for (int i = 0; i < slots.Count; i++)
        {
            activeSlots++;

            if (slots[i].GetDice().prize == DiceControll.Prize.Item)
                combo = true;
            else
            {
                combo = false;
                return combo;
            }
        }
        return combo;
    }
    private bool CheckLineCombo(Raid_UI slot_1, Raid_UI slot_2, Raid_UI slot_3)
    {
        if(slot_1.isOpened && slot_1.m_currentHero != null &&
                slot_2.isOpened && slot_2.m_currentHero != null &&
                slot_3.isOpened && slot_3.m_currentHero != null)
        {
            if (slot_1.GetDice().prize == DiceControll.Prize.Item &&
                slot_2.GetDice().prize == DiceControll.Prize.Item &&
                slot_3.GetDice().prize == DiceControll.Prize.Item)
            {
                return true;
            }
        }
        return false;
    }
    private void ItemsAwarding(List<Item> winItems)
    {
        for (int i = 0; i < winItems.Count; i++)
        {
            GlovalEventSystem.ItemAddingToInventory(winItems[i]);
        }
        GlovalEventSystem.WinItems(winItems);
    }
    private void GoldBoostActivate(int value) => m_boostGold = value;
    private void ItemBoostActivate(int value) => m_boostItem = value;
    private void GoldBoostDeActivate() => m_boostGold = 1;
    private void ItemBoostDeActivate() => m_boostItem = 1;
    private void CloseCombo()
    {
        firstLine_horizontal.SetActive(false);
        firstLine_vertical.SetActive(false);
        secondLine_horizontal.SetActive(false);
        secondLine_vertical.SetActive(false);
        thirdLine_horizontal.SetActive(false);
        thirdLine_vertical.SetActive(false);
        diagonallyLine_toDown.SetActive(false);
        diagonallyLine_toUp.SetActive(false);
    }
}
