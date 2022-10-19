using UnityEngine;
[System.Serializable]
public class Quest
{
    public bool isActive;
    public bool PassItems;
    public int id;
    public string Descripsion;
    public enum RewardType
    {
        Hero,
        Gold,
        Boost,
        Location,
        Slot
    }
    public RewardType rewardType;

    public Hero HeroReward;
    public long GoldReward;
    public Zone Location;
    public BoostCard BoostCard;
    public Sprite RewardIcon;
    public bool isCustomReward = false;
    public int customRewardID = 0;
    public BoostCard customBoost;
    public Goal goal;

}
