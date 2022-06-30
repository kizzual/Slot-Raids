using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public static long currentGold = 100000000;
    private static Text goldText;
    private void Awake()
    {
        if(PlayerPrefs.HasKey("Gold"))
            LoadGold();

        goldText = GetComponentInChildren<Text>();
        goldText.text = ConvertText.FormatNumb(currentGold);
    }

    public static void AddGold(int value)
    {
        currentGold += value;
        goldText.text = ConvertText.FormatNumb(currentGold);
    }

    public static void SpendGold(long value)
    {
        currentGold -= value;
        goldText.text = ConvertText.FormatNumb(currentGold);
    }
    public static long GetCurrentGold() => currentGold;
    public static void SaveGold() => PlayerPrefs.SetInt("Gold", (int)currentGold);
    private void LoadGold() => currentGold = PlayerPrefs.GetInt("Gold");
}
