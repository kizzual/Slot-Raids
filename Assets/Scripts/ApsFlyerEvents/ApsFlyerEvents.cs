using AppsFlyerSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ApsFlyerEvents : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void OpenLevel_event(int level_number)
    {
        Debug.Log("Events 'Open Level' sended with parametrs:  level_number = " + level_number);
        Dictionary<string, string> levelEvent = new Dictionary<string, string>();
        levelEvent.Add("level_number", level_number.ToString());
        levelEvent.Add("level_name", "race");
        AppsFlyer.sendEvent("level", levelEvent);
    }
    public static void LevelStatus_event(string status, int level_number, int cupsCount)
    {
        Debug.Log("Events 'level Status' sended with parametrs:  status = " + status + " level number = "+ level_number + " cups " + cupsCount);
        Dictionary<string, string> levelStatus= new Dictionary<string, string>();
        levelStatus.Add("status", status);
        levelStatus.Add("level_number", level_number.ToString());
        levelStatus.Add("level_name", "race");
        levelStatus.Add("bowls_number", cupsCount.ToString());
        AppsFlyer.sendEvent("level_winrate", levelStatus);
    }
    public static void EngineUpgrade_event(string upgradeName, int gradeLevel)
    {
        Debug.Log("Events 'engie upgrade' sended with parametrs:  upgradeName = " + upgradeName + " gradeLevel = " + gradeLevel );
        Dictionary<string, string> engineUpgrade = new Dictionary<string, string>();
        engineUpgrade.Add("upgrade_name", upgradeName);
        engineUpgrade.Add("upgrade_level", gradeLevel.ToString());
        AppsFlyer.sendEvent("engine_upgrade", engineUpgrade);
    }
}
