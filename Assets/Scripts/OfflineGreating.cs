using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfflineGreating : MonoBehaviour
{
    public static OfflineGreating _instanse;
    [SerializeField] private Image firstItem;
    [SerializeField] private Image secondItem;
    [SerializeField] private Text goldCount;
    [SerializeField] private Text firstItemCount;
    [SerializeField] private Text secondItemCount;
    [SerializeField] private Image iampImage;
    [SerializeField] private Text nameLocation;


    private void Awake()
    {
        _instanse = this;
    }
    public void OfflineReward(long goldValue, List<Item> winItems )
    {
        gameObject.SetActive(true);
        List<Item> first_item = new List<Item>();
        List<Item> second_item = new List<Item>();
        if(winItems.Count > 0)
        {
            first_item.Add(winItems[0]);
            winItems.RemoveAt(0);
            for (int i = 0; i < winItems.Count; i++)
            {
                if(winItems[i] == first_item[0])
                {
                    first_item.Add(winItems[i]);
                    winItems.RemoveAt(i);
                }
                else
                {
                    second_item.Add(winItems[i]);
                    winItems.RemoveAt(i);
                }
            }

            if (first_item.Count > 0)
            {
                firstItem.gameObject.SetActive(true);
                firstItemCount.gameObject.SetActive(true);
                firstItem.sprite = first_item[0].GetComponent<Image>().sprite;
                firstItemCount.text = first_item.Count.ToString();
            }
            else
            {
                firstItem.gameObject.SetActive(false);
                firstItemCount.gameObject.SetActive(false);
            }
            if (second_item.Count > 0)
            {
                secondItem.gameObject.SetActive(true);
                secondItemCount.gameObject.SetActive(true);
                secondItem.sprite = second_item[0].GetComponent<Image>().sprite;
                secondItemCount.text = first_item.Count.ToString();
            }
            else
            {
                secondItem.gameObject.SetActive(false);
                secondItemCount.gameObject.SetActive(false);
            }
            goldCount.text = ConvertText.FormatNumb(goldValue);
        }
        switch (CurrentZone.Current_Zone.typeElement)
        {
            case Type__Element.Neutral:
                nameLocation.text = "MAGIC WOOD";
                break;
            case Type__Element.Undead:
                nameLocation.text = "DARK FOREST";
                break;
            case Type__Element.Order:
                nameLocation.text = "ARENA";
                break;
            case Type__Element.Demon:
                nameLocation.text = "FIRE LAND";
                break;

        }
        
        iampImage.sprite = CurrentZone.Current_Zone.logo;
    }
   public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

}
