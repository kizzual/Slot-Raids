using System;
using System.Collections.Generic;

public static class GlovalEventSystem 
{
    public static Action<Hero> OnHeroUpgrade;
    public static Action<Raid_UI> OnAddingHeoToSlot;
    public static Action<int> OnRemoveFromSlot;
    public static Action<Zone> OnSwitchLocation;
    public static Action<Hero> OnHOpenHeroStats;
    public static Action<Hero> OnAddingSword;
    public static Action<Hero> OnAddingShield;
    public static Action<Hero> OnAddingAmulet;
    public static Action<int> OnUpgradeTower;
    public static Action<Item,int, Inventory_controll> OnSellingItem;
    public static Action<Item> OnItemAddingToInventory;
    public static Action<long> OnWinGold;
    public static Action<List<Item>> OnWinItems;
    public static Action<List<Raid_UI>> OnRaidComplete;
    public static Action OnRotateComplete;
    public static Action<List<Item>, long, int, int > OnCheckAchievement;
    public static Action <int> OnGoldBoostActivate;
    public static Action  OnGoldBoostDeActivate;
    public static Action <int> OnItemBoostActivate;
    public static Action  OnItemBoostDeActivate;
    public static Action  OnRaidStart;
    public static Action  OnBoostIsReady;
    public static Action  OnBoostIsNotReady;
    public static Action <int>  OnTutorialSteps;
    public static Action <int>  OnTutorialStepsSecondPart;
    public static Action <int>  OnTutorialStepsThirdPart;
    public static Action <TimeSpan>  OnCheckOfflineTime;

    public static void RotateComplete() => OnRotateComplete?.Invoke();
    public static void CheckOfflineTime(TimeSpan ts) => OnCheckOfflineTime?.Invoke(ts);
//    public static void TutorialSteps(int stepNumber) => OnTutorialSteps?.Invoke(stepNumber);
//    public static void TutorialStepsSecondPart(int stepNumber) => OnTutorialStepsSecondPart?.Invoke(stepNumber);
 //   public static void TutorialStepsThirdPart(int stepNumber) => OnTutorialStepsThirdPart?.Invoke(stepNumber);
    public static void BoostIsReady() => OnBoostIsReady?.Invoke();
    public static void BoostIsNotReady() => OnBoostIsNotReady?.Invoke();
    public static void HeroUpgrade(Hero hero) => OnHeroUpgrade?.Invoke(hero);
    public static void AddingHeroToSlot(Raid_UI slot) => OnAddingHeoToSlot?.Invoke(slot);
    public static void RemoveFromSlot(int slotNum) => OnRemoveFromSlot?.Invoke(slotNum);
    public static void OpenHeroStats(Hero hero) => OnHOpenHeroStats?.Invoke(hero);
    public static void Adding_sword(Hero hero) => OnAddingSword?.Invoke(hero);
    public static void Adding_shield(Hero hero) => OnAddingShield?.Invoke(hero);
    public static void Adding_amulet(Hero hero) => OnAddingAmulet?.Invoke(hero);
    public static void SwitchLocation(Zone zone) => OnSwitchLocation?.Invoke(zone);
    public static void UpgradeTower(int currentGrade) => OnUpgradeTower?.Invoke(currentGrade);
    public static void SellingItem(Item item, int count, Inventory_controll inventory_Controll) => OnSellingItem?.Invoke(item, count, inventory_Controll);
    public static void ItemAddingToInventory(Item item) => OnItemAddingToInventory?.Invoke(item);
    public static void RaidComplete(List<Raid_UI> slots) => OnRaidComplete?.Invoke(slots);
    public static void WinGold(long value) => OnWinGold?.Invoke(value);
    public static void WinItems(List<Item> items) => OnWinItems?.Invoke(items);
    public static void CheckAchievement(List<Item> items, long goldValue, int comboValue, int unLuckValue) => OnCheckAchievement?.Invoke(items, goldValue, comboValue, unLuckValue);
    public static void GoldBoostActivate(int value) => OnGoldBoostActivate?.Invoke(value);
    public static void GoldBoostDeActivate() => OnGoldBoostDeActivate?.Invoke();
    public static void ItemBoostActivate(int value) => OnItemBoostActivate?.Invoke(value);
    public static void ItemBoostDeActivate() => OnItemBoostDeActivate?.Invoke();
    public static void RaidStart() => OnRaidStart?.Invoke();


}
