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
    [SerializeField] private Image quest_complete_button;


 
    public void Initialise_quest(Quest quest)
    {
   //     second_count.gameObject.SetActive(false);
    //    second_item_image.gameObject.SetActive(false);

        quest_title.text = quest.Titile;
        quest_description.text = quest.Descripsion;
        first_count.text = quest.goal.currentAmount.ToString() + "/" + quest.goal.requiredAmount.ToString();
        prize_image.sprite = quest.RewardIcon;
    }

    public void QuestComplete()
    {
        // включить квест комплит кнопку
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
