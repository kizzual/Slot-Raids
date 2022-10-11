using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace test
{
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
        public void OfflineReward(long goldValue, List<Item> winItems)
        {
            if (goldValue > 0 || winItems.Count > 0)
            {
                gameObject.SetActive(true);
                AddWinItems(winItems);
                ChooseNameLocation();
                goldCount.text = ConvertText.FormatNumb(goldValue);
            }
        }
        private void AddWinItems(List<Item> winItems)
        {
            List<Item> first_item = new List<Item>();
            List<Item> second_item = new List<Item>();
            if (winItems.Count > 0)
            {
                first_item.Add(winItems[0]);
                winItems.RemoveAt(0);
                for (int i = 0; i < winItems.Count; i++)
                {
                    if (winItems[i] == first_item[0])
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
                ActivateItem(first_item, firstItem, firstItemCount);
                ActivateItem(second_item, secondItem, secondItemCount);
            }
        }
        private void ActivateItem(List<Item> items, Image imgItem, Text textItemCount)
        {
            if (items.Count > 0)
            {
                imgItem.gameObject.SetActive(true);
                textItemCount.gameObject.SetActive(true);
                imgItem.sprite = items[0].GetComponent<Image>().sprite;
                textItemCount.text = items.Count.ToString();
            }
            else
            {
                imgItem.gameObject.SetActive(false);
                textItemCount.gameObject.SetActive(false);
            }
        }

        private void ChooseNameLocation()
        {
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
}
