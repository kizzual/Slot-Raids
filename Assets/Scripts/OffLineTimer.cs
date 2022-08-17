using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OffLineTimer : MonoBehaviour
{
    public static OffLineTimer _instance;
    private void InitSingleton()
    {
        _instance = this;
    }
    public static TimeSpan OfflineTime;
    public List<Raid_button> raid_button;
    public void Awake()
    {
        InitSingleton();
        ChecckOffline();
    }
    public void ChecckOffline()
    {
        if(PlayerPrefs.HasKey("LastSession"))
        {
            OfflineTime = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            Debug.Log("Offline = " + OfflineTime.Minutes + " минут  " + OfflineTime.Seconds + " секунд");
        }
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Debug.Log("GoToOffline");
            if (raid_button[0].isActive || raid_button[1].isActive || raid_button[2].isActive || raid_button[3].isActive)
                PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
            else
                PlayerPrefs.DeleteKey("LastSession");
        }
     
    }
    private void OnApplicationQuit()
    {
        Debug.Log("GoToOffline");
        if (raid_button[0].isActive || raid_button[1].isActive || raid_button[2].isActive || raid_button[3].isActive)
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        else
            PlayerPrefs.DeleteKey("LastSession");
    }

}
