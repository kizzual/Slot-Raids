using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private Text raidCount;
    [SerializeField] private Text goldCount;
    public void Initialise(long goldValue, int raidsCount)
    {
        raidCount.text = ConvertText.FormatNumb(raidsCount);
        goldCount.text = ConvertText.FormatNumb(goldValue);
    }
    public void GoldValue(long value) => goldCount.text = ConvertText.FormatNumb(value);
    public void RaidValue(int value) => raidCount.text = ConvertText.FormatNumb(value);
}
