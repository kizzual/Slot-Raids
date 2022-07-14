using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hero : MonoBehaviour
{
    public TypeElement typeElement;
    public TypeBonus typeBonus;
    public Sprite Icon;
    [Space]
    [Header("Settings")]
    [SerializeField] private int StartGold;
    [SerializeField] private int StartetMultiplier;
    [SerializeField] private int Combo;
    [SerializeField] private int Luck;
    [SerializeField] private int UnLuck;
    [SerializeField] private int Base_Grade;
    [SerializeField] private int Grade_percent;
    [Space]
    /// Bonus
    [Header("Element Bonus")]
    [SerializeField] private int Gold_Element_bonus;
    [SerializeField] private int Luck_Element_bonus;
    [SerializeField] private int Protect_Element_bonus;
    [SerializeField] private int Combo_Element_bonus;
    /// Bonus

    public int Level { get; set; } = 1;
    public int Rank { get; set; }
    public long GoldToGrade { get; set; }
    public long GoldProfit { get; set; }
    public int Multiplier { get; set; }
    public int currentRaidSlot { get; set; }
    public bool isOpened;


    public Item m_sword;
    public Item m_shield;
    public Item m_amulet;
     
    public Item GetItem_Sword()
    {
        if (m_sword != null)
            return m_sword;
        else
            return null;
    }
    public Item GetItem_Shield()
    {
        if (m_shield != null)
            return m_shield;
        else
            return null;
    }
    public Item GetItem_Amulet()
    {
        if (m_amulet != null)
            return m_amulet;
        else
            return null;
    }
    public void LevelUp()
    {
        Level++;
        // изменение спрайтов больших и Rank
        ChangeMultiplier();
        ChangeGoldToGrade();
    }
    public void AddItem(Item item)
    {
        RemoveCurrentItem(item);
        if (item.typeItem == TypeItem.Sword)
        {
            m_sword = item;
            StartGold += Mathf.RoundToInt(StartGold * (item.Gold_profit / 100f));
        }
        else if (item.typeItem == TypeItem.Shield)
        {
            m_shield = item;
            UnLuck -= item.Protect_profit;
        }
        else if(item.typeItem == TypeItem.Amulet)
        {
            m_amulet = item;
            Luck += item.Luck_profit;
        }
        // если текущий айтем == меч ( старт голд += стартголд * процент меча )
        // если ткущий айтем щит  == щит ( анлак -= процент щита )
        // если текущий айтем амулет == амулет  ( лак + амулет процент)
    }
    public void RemoveCurrentItem(Item item)
    {
        if(item.typeItem == TypeItem.Sword && m_sword != null)
        {
            StartGold -= Mathf.RoundToInt(StartGold * (m_sword.Gold_profit / 100f));
            m_sword = null;
        }
        else if (item.typeItem == TypeItem.Shield && m_shield != null)
        {
            UnLuck += item.Protect_profit;
            m_shield = null;
        }
        else if (item.typeItem == TypeItem.Amulet && m_amulet != null)
        {
            Luck -= item.Luck_profit;
            m_amulet = null;
        }
    }
    public long GetGoldProfit() // реализация для всех панелей кроме рейда (если тру для рейда)
    {
        if (currentRaidSlot != 0)
        {
            if (CurrentZone.Current_Zone.typeElement == Type__Element.Neutral && typeElement == TypeElement.Neutral ||
                CurrentZone.Current_Zone.typeElement == Type__Element.Undead && typeElement == TypeElement.Undead ||
                CurrentZone.Current_Zone.typeElement == Type__Element.Order && typeElement == TypeElement.Order ||
                CurrentZone.Current_Zone.typeElement == Type__Element.Demon && typeElement == TypeElement.Demon)
            {
                return (StartGold * Multiplier) + (StartGold * Multiplier / 100 * Gold_Element_bonus);
            }
            else
                return StartGold * Multiplier;
        }
        else
            return StartGold * Multiplier;
    }
    public int GetLuckProfit()
    {
        if (currentRaidSlot != 0)
        {

            if (CurrentZone.Current_Zone.typeElement == Type__Element.Neutral && typeElement == TypeElement.Neutral ||
                CurrentZone.Current_Zone.typeElement == Type__Element.Undead && typeElement == TypeElement.Undead ||
                CurrentZone.Current_Zone.typeElement == Type__Element.Order && typeElement == TypeElement.Order ||
                CurrentZone.Current_Zone.typeElement == Type__Element.Demon && typeElement == TypeElement.Demon)
            {
                return Luck + Luck_Element_bonus;
            }
            else
                return Luck;
        }
        else
            return Luck;
    }
    public int GetUnLuckProfit()
    {
        if (currentRaidSlot != 0)
        {

            if (CurrentZone.Current_Zone.typeElement == Type__Element.Neutral && typeElement == TypeElement.Neutral ||
                CurrentZone.Current_Zone.typeElement == Type__Element.Undead && typeElement == TypeElement.Undead ||
                CurrentZone.Current_Zone.typeElement == Type__Element.Order && typeElement == TypeElement.Order ||
                CurrentZone.Current_Zone.typeElement == Type__Element.Demon && typeElement == TypeElement.Demon)
            {
                return Luck + Luck_Element_bonus;
            }
            else
                return UnLuck;
        }
        else
            return UnLuck;
    }
    public int GetCombo() => Combo;
    private void ChangeGoldToGrade()
    {
        if (Level != 1)
        {
            GoldToGrade += Mathf.RoundToInt((GoldToGrade / 100f * Grade_percent));
        }
        else
            GoldToGrade = Base_Grade;
    }
    private void ChangeMultiplier()
    {
        if (Level != 1)
        {
            Multiplier += StartetMultiplier / 2;
        }
        else
            Multiplier = StartetMultiplier;
    }

 
    public void Initialise()
    {
        ChangeGoldToGrade();
        ChangeMultiplier();
        if (Level < 50)
            Rank = 1;
    }
}




[System.Serializable]
public enum TypeElement
{
    Neutral,
    Undead,
    Order,
    Demon
}
[System.Serializable]
public enum TypeBonus
{
    GoldProfit_Percent,
    Luck_percent,
    Protect_percent,
    Combo_percent
}
