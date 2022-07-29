using UnityEngine;


public class Hero : MonoBehaviour
{
    public TypeElement typeElement;
    public TypeBonus typeBonus;
    public Sprite Icon;
    public Cube cube;
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
    public int Id;
    public Item m_sword { get; set; }
    public Item m_shield { get; set; }
    public Item m_amulet { get; set; }
    public string HeroName;
    private int m_swordBonus;
    private int m_luckBoost = 0;
    private int m_unLuckBoost = 0;
    private int m_combo = 0;
    private int m_discounteToGrade = 1;
    public int profitBoost { get; set; } = 1;
    public int itemProfitBoost { get; set; } = 1;
    public int raidsCount { get; set; } = 0;
    public void AddBust(int luck, int unLuck, int combo, int goldProfit, int itemProfit)
    {
        m_luckBoost = luck;
        m_unLuckBoost = unLuck;
        m_combo = combo;
        profitBoost = goldProfit;
        itemProfitBoost = itemProfit;
        Luck += m_luckBoost;
        UnLuck -= m_unLuckBoost;
        Combo += m_combo;

    }
    public void RemoveBoost()
    {
        Luck -= m_luckBoost;
        UnLuck += m_unLuckBoost;
        Combo -= m_combo;
        m_luckBoost = 0;
        m_unLuckBoost = 0;
        m_combo = 0;
        profitBoost = 1;
        itemProfitBoost = 1;
        m_discounteToGrade = 1;
    }
    public void AddDiscountBoost(int value)
    {
        m_discounteToGrade = value;
    }
    public void GoToRaid()
    {
        raidsCount++;
    }
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
        if (Level < 50)
            Rank = 1;
        else if (Level >= 50 && Level < 99)
            Rank = 2;
        else
            Rank = 3;
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
            m_swordBonus = Mathf.RoundToInt(StartGold * (item.Gold_profit / 100f));
            StartGold += m_swordBonus;
        }
        else if (item.typeItem == TypeItem.Shield)
        {
            m_shield = item;
            UnLuck -= item.Protect_profit;
        }
        else if (item.typeItem == TypeItem.Amulet)
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
        if (item.typeItem == TypeItem.Sword && m_sword != null)
        {
            StartGold -= m_swordBonus;
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
                if (typeBonus == TypeBonus.Luck_percent)
                {
                    return Luck + Luck_Element_bonus + CurrentZone.Current_Zone.Luck;
                }
                else
                    return Luck + CurrentZone.Current_Zone.Luck;
            }
            else
                return Luck + CurrentZone.Current_Zone.Luck;
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
                if (typeBonus == TypeBonus.Protect_percent)
                    return UnLuck - Protect_Element_bonus + CurrentZone.Current_Zone.UnLuck;
                else
                    return UnLuck + CurrentZone.Current_Zone.UnLuck;
            }
            else
                return UnLuck + CurrentZone.Current_Zone.UnLuck;
        }
        else
            return UnLuck;
    }
    public int GetCombo() => Combo;
    private void ChangeGoldToGrade()
    {
        if (m_discounteToGrade != 1)
        {
            if (Level != 1)
            {
                GoldToGrade += Mathf.RoundToInt((GoldToGrade / 100f * Grade_percent));
                GoldToGrade -= Mathf.RoundToInt((GoldToGrade / 100f) * m_discounteToGrade);
            }
            else
            {
                GoldToGrade = Base_Grade;
                GoldToGrade -= Mathf.RoundToInt((GoldToGrade / 100f) * m_discounteToGrade);
            }
        }
        else
        {
            if (Level != 1)
            {
                GoldToGrade += Mathf.RoundToInt((GoldToGrade / 100f * Grade_percent));
            }
            else
                GoldToGrade = Base_Grade;
        }
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
        else if (Level >= 50 && Level < 99)
            Rank = 2;
        else
            Rank = 3;
    }
    public void DisplayCubeInfo()
    {
        int luckCount = Mathf.RoundToInt((cube.edgesNumber / 100f) * GetLuckProfit());
        int UnLuckCount = Mathf.RoundToInt((cube.edgesNumber / 100f) * GetUnLuckProfit());
        cube.SwitchColors(UnLuckCount, luckCount);
    }
    public void LoadHero(HeroSaver hero)
    {
        Level = hero.Level;
        currentRaidSlot = hero.CurrentSlot;
        isOpened = hero.IsOpened;
        if (hero.Sword != null)
            AddItem(hero.Sword);
        if (hero.Shield != null)
            AddItem(hero.Sword);
        if (hero.Amulet != null)
            AddItem(hero.Amulet);
        Initialise();
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
