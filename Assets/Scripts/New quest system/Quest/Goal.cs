[System.Serializable]
public class Goal
{
    public GoalType goalType;
    public TypElement elementType;

    public long requiredAmount;
    public long currentAmount;

    public Item firstItem;
    public Item secondItem;
    public Item thirdItem;
    public int firstItem_requiredAmount;
    public int firstItem_currentAmount;
    public int secondItem_requiredAmount;
    public int secondItem_currentAmount;
    public int thirdItem_requiredAmount;
    public int thirdItem_currentAmount;

    public Hero HeroToRaid;
    public Zone ZoneToRaid;
    public bool IsReached() => (currentAmount >= requiredAmount);

    public bool IsItemColeted() => (firstItem_currentAmount >= firstItem_requiredAmount && secondItem_currentAmount >= secondItem_requiredAmount && thirdItem_currentAmount >= thirdItem_requiredAmount);
    public void GoldGathering(long value) => currentAmount = value;
 //   public void ComboGathering(int value) => currentAmount += value;
    public void RaidGathering(int value) => currentAmount = value;
    public void UpgradeTower(int value) => currentAmount = value;
   // public void LuckGathering(int value) => currentAmount += value;
  //  public void UnLuckGathering(int value) => currentAmount += value;
    public void FirstItemGathering(int value) => firstItem_currentAmount = value;
    public void SecondItemGathering(int value) => secondItem_currentAmount = value;
    public void ThirdItemGathering(int value) => thirdItem_currentAmount = value;
    public void RaidGarhering_byElement(int value) => currentAmount = value;
    public void RaidGarhering_byZone(int value) => currentAmount = value;
    public void HeroRaid() => currentAmount = HeroToRaid.raidsCount;

}
public enum GoalType
{
    Gold_Gathering,
    Item_Gathering,
    Combo_Gathering,
    Raid_Gathering,
    Upgrade_Tower,
    Death_Gathering,
    Luck_Gathering,
    raid_Gathering_byElement,
    Raid_ByZone,
    heroRaid
}
public enum TypElement
{
    Neutral,
    Undead,
    Order,
    Demon
}
