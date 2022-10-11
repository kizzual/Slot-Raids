using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public static class Utils 
{
    public static void SetDataTime(DateTime value,string namePlayerPrefs)
    {
        string convertedToString = value.ToString("u", CultureInfo.InvariantCulture);
        PlayerPrefs.SetString(namePlayerPrefs,convertedToString);
    }
    public static DateTime GetDateTime(string namePlayerPrefs)
    {
        if (PlayerPrefs.HasKey(namePlayerPrefs))
        {
            string stored = PlayerPrefs.GetString(namePlayerPrefs);
            DateTime result = DateTime.ParseExact(stored, "u", CultureInfo.InvariantCulture);
            return result;
        }
        else
        {
            return DateTime.UtcNow;
        }
    }
    public static void SetLastTime( string namePlayerPrefs)
    {
        string convertedToString = DateTime.UtcNow.ToString("u", CultureInfo.InvariantCulture);
        PlayerPrefs.SetString(namePlayerPrefs, convertedToString);
    }
    public static DateTime GetDateLastTime(string namePlayerPrefs)
    {
        if (PlayerPrefs.HasKey(namePlayerPrefs))
        { 
            string stored = PlayerPrefs.GetString(namePlayerPrefs);
            DateTime result = DateTime.ParseExact(stored, "u", CultureInfo.InvariantCulture);
            return result;
        }
        else
        {
            return DateTime.UtcNow;
        }
    }
    // Get the difference between the latest online
    public static long GetSeconds(string namePlayerPrefs)
    {
        if (PlayerPrefs.HasKey(namePlayerPrefs))
        {
            string stored = PlayerPrefs.GetString(namePlayerPrefs);
            DateTime result = DateTime.ParseExact(stored, "u", CultureInfo.InvariantCulture);    

            return (((result.Hour * 60) + result.Minute) * 60) + result.Second;
        }
        else
        {
            return 0;
        }
    }
    public static long GetMinutes(string namePlayerPrefs)
    {
        if (PlayerPrefs.HasKey(namePlayerPrefs))
        {
            string stored = PlayerPrefs.GetString(namePlayerPrefs);
            DateTime result = DateTime.ParseExact(stored, "u", CultureInfo.InvariantCulture);

            return ((result.Hour * 60) + result.Minute);
        }
        else
        {
            return 0;
        }
    }

}
