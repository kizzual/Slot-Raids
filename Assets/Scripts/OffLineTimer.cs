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
     //   InitSingleton();
     //   ChecckOffline();
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
            if (PlayerPrefs.HasKey("TutorSave") && PlayerPrefs.GetInt("TutorSave") == 4)
            {
                Debug.Log("GoToOffline");
                PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
            }
        }

     
    }
    private void OnApplicationQuit()
    {
        if (PlayerPrefs.HasKey("TutorSave") && PlayerPrefs.GetInt("TutorSave") == 4)
        {
            Debug.Log("GoToOffline");
            if (Tutorial.CheckTutorStep() >= 20)
            {
                PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
            }
        }
    }

}
