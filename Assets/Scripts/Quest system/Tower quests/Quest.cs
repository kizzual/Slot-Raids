using UnityEngine;
[System.Serializable]
public class Quest
{
    public bool isActive;
    public bool PassItems;
    public string Titile;
    public string Descripsion;
    public enum RewardType
    {
        Hero,
        Gold,
        Boost
    }
    public RewardType rewardType;

    public Hero HeroReward;
    public long GoldReward;

    public Sprite RewardIcon;
    public QuestGoal goal;

}
