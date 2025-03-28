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
    [SerializeField] private Text third_count;
    [SerializeField] private Image first_item_image;
    [SerializeField] private Image second_item_image;
    [SerializeField] private Image third_item_image;
    [SerializeField] private Image prize_image;
    [SerializeField] private GameObject quest_complete_button;
    [SerializeField] private GameObject quest_complete_button_green;



    public void Initialise_quest(Quest quest)
    {
        second_item_image.gameObject.SetActive(false);
        third_item_image.gameObject.SetActive(false);

        quest_complete_button.SetActive(true);
        quest_complete_button_green.SetActive(false);


        quest_title.text = quest.id.ToString();
        quest_description.text = quest.Descripsion;
        prize_image.sprite = quest.RewardIcon;

        if (quest.goal.secondItem != null)
        {
            second_item_image.gameObject.SetActive(true);
            second_item_image.sprite = quest.goal.secondItem.GetComponent<Image>().sprite;
            second_count.text = quest.goal.secondItem_currentAmount.ToString() + "/" + quest.goal.secondItem_requiredAmount.ToString();

        }
        if (quest.goal.firstItem == null)
        {
            first_item_image.enabled = false;
        }
        else
        {
            first_item_image.enabled = true;
            first_item_image.sprite = quest.goal.firstItem.GetComponent<Image>().sprite;
            third_count.text = quest.goal.thirdItem_currentAmount.ToString() + "/" + quest.goal.thirdItem_requiredAmount.ToString();
        }

        if (quest.goal.thirdItem == null)
        {
            third_item_image.enabled = false;
        }
        else
        {
            third_item_image.enabled = true;
            third_item_image.sprite = quest.goal.thirdItem.GetComponent<Image>().sprite;
        }
        if (quest.goal.goalType == GoalType.Item_Gathering)
        {
            first_count.text = quest.goal.firstItem_currentAmount.ToString() + "/" + quest.goal.firstItem_requiredAmount.ToString();
        }
        else if (quest.goal.goalType == GoalType.Gold_Gathering)
        {

            first_count.text = ConvertText.FormatNumb(quest.goal.currentAmount) + "/" + ConvertText.FormatNumb(quest.goal.requiredAmount);
        }
        else
        { 
            first_count.text = quest.goal.currentAmount.ToString() + "/" + quest.goal.requiredAmount.ToString();
        }
    }

    public void QuestComplete()
    {
        quest_complete_button.SetActive(false);
        quest_complete_button_green.SetActive(true);
    }
}
