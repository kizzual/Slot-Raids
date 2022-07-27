using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_q_UI : MonoBehaviour
{
    [SerializeField] private Text quest_title;
    [SerializeField] private Text quest_description;
    [SerializeField] private Text first_count;
    [SerializeField] private Text second_count;
    [SerializeField] private Image first_item_image;
    [SerializeField] private Image second_item_image;
    [SerializeField] private Image prize_image;
    [SerializeField] private GameObject quest_complete_button;
    [SerializeField] private GameObject quest_complete_button_green;


 
    public void Initialise_quest(Quest quest)
    {
        second_item_image.gameObject.SetActive(false);
        quest_complete_button.SetActive(true);
        quest_complete_button_green.SetActive(false);
        if(quest.goal.secondItem != null)
        {
            second_item_image.gameObject.SetActive(true);
            second_item_image.sprite = quest.goal.secondItem.GetComponent<Image>().sprite;
        }
        if(quest.goal.firstItem == null)
            first_item_image.enabled = false;
        else
        {
            first_item_image.enabled = true;
            first_item_image.sprite = quest.goal.firstItem.GetComponent<Image>().sprite;
        }
        quest_title.text = quest.id.ToString();
        quest_description.text = quest.Descripsion;
        first_count.text = quest.goal.currentAmount.ToString() + "/" + quest.goal.requiredAmount.ToString();
        prize_image.sprite = quest.RewardIcon;
    }

    public void QuestComplete()
    {
        quest_complete_button.SetActive(false);
        quest_complete_button_green.SetActive(true);
    }




    /*  public void Initialise_quest(Quest quest)
      {
          second_count.gameObject.SetActive(false);
          second_item_image.gameObject.SetActive(false);
          CurrentQuest = quest;

      //    quest_title.text = quest.Titile;
      //    quest_description.text = quest.Destipsion;
       //   if(quest.questType == Quest.QuestType.Get_gold)
      }
      public void QuestComplete()
      {

      }*/
}
