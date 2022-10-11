using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace test
{
    public class OffLineTimer : MonoBehaviour
    {
        //public static OffLineTimer _instance;
        //private void InitSingleton()
        //{
        //    _instance = this;
        //}
        public static TimeSpan OfflineTime;
        //public List<Raid_button> raid_button;
        //public void Awake()
        //{
        // //   InitSingleton();
        // //   ChecckOffline();
        //}
        public void ChecckOffline()
        {
            //твой вариант
            //if(PlayerPrefs.HasKey("LastSession"))
            //{
            //    OfflineTime = DateTime.UtcNow - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            //    Debug.Log("Offline = " + OfflineTime.Minutes + " минут  " + OfflineTime.Seconds + " секунд");
            //}
            //мой вариант
            OfflineTime = Utils.GetDateLastTime("LastSession").TimeOfDay;
        }
        private void OnApplicationPause(bool pause)
        {

            if (pause)
            {
                //if (PlayerPrefs.HasKey("TutorSave") && PlayerPrefs.GetInt("TutorSave") == 4)
                //{
                //Debug.Log("GoToOffline");
                //PlayerPrefs.SetString("LastSession", DateTime.UtcNow.ToString());
                //}
                Utils.SetLastTime("LastSession");
            }


        }
        private void OnApplicationQuit()
        {
            //if (PlayerPrefs.HasKey("TutorSave") && PlayerPrefs.GetInt("TutorSave") == 4)
            //{
            //Debug.Log("GoToOffline");
            //if (Tutorial.CheckTutorStep() >= 20)
            //{
            //    PlayerPrefs.SetString("LastSession", DateTime.UtcNow.ToString());
            //}
            //}
            Utils.SetLastTime("LastSession");
        }

    }
}
