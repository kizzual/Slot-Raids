using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public long requiredAmount;
    public long currentAmount;

    public Item firstItem;
    public Item secondItem;
    public int firstItem_requiredAmount;
    public int firstItem_currentAmount;
    public int secondItem_requiredAmount;
    public int secondItem_currentAmount;
    public bool IsReached() => (currentAmount >= requiredAmount);

    public bool IsItemColeted() => (firstItem_currentAmount >= firstItem_requiredAmount && secondItem_currentAmount >= secondItem_requiredAmount);
    public void GoldGathering(long value) => currentAmount = value;
    public void ComboGathering(int value) => currentAmount += value;
    public void RaidGathering(int value) => currentAmount += value;
    public void UpgradeTower(int value) => currentAmount = value;
    public void LuckGathering(int value) => currentAmount += value;
    public void UnLuckGathering(int value) => currentAmount += value;
    public void ItemGathering(int firstItemCount, int secondItemCount)
    {
        firstItem_currentAmount += firstItemCount;
        secondItem_currentAmount += secondItemCount;
    }
}
public enum GoalType
{
    Gold_Gathering,
    Item_Gathering,
    Combo_Gathering,
    Raid_Gathering,
    Upgrade_Tower,
    Death_Gathering,
    Luck_Gathering
}

