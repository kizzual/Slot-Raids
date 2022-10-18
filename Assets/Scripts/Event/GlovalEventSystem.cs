using System;
using System.Collections.Generic;

public static class GlovalEventSystem 
{
    public static Action<Hero> OnHeroUpgrade;
    public static Action<Raid_UI> OnAddingHeoToSlot;
    public static Action<Zone> OnSwitchLocation { get; set; }
    public static Action<Hero> OnHOpenHeroStats;

    public static Action OnRotateComplete;


    public static Action  OnBoostIsReady { get; set; }
    public static Action  OnBoostIsNotReady { get; set; }


    public static void RotateComplete() => OnRotateComplete?.Invoke();

    public static void BoostIsReady() => OnBoostIsReady?.Invoke();
    public static void BoostIsNotReady() => OnBoostIsNotReady?.Invoke();
    public static void HeroUpgrade(Hero hero) => OnHeroUpgrade?.Invoke(hero);
    public static void AddingHeroToSlot(Raid_UI slot) => OnAddingHeoToSlot?.Invoke(slot);
    public static void OpenHeroStats(Hero hero) => OnHOpenHeroStats?.Invoke(hero);

    public static void SwitchLocation(Zone zone) => OnSwitchLocation?.Invoke(zone);




}
