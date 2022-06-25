using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public static int currentGold = 100;
    private static Text goldText;
    private void Awake()
    {
        if(PlayerPrefs.HasKey("Gold"))
            LoadGold();

        goldText = GetComponentInChildren<Text>();
        goldText.text = currentGold.ToString();
    }

    public static void AddGold(int value)
    {
        currentGold += value;
        goldText.text = currentGold.ToString();
    }

    public static void SpendGold(int value)
    {
        currentGold -= value;
        goldText.text = currentGold.ToString();
    }
    public static int GetCurrentGold() => currentGold;
    public static void SaveGold() => PlayerPrefs.SetInt("Gold", currentGold);
    private void LoadGold() => currentGold = PlayerPrefs.GetInt("Gold");
}
