using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_q_UI : MonoBehaviour
{
    [SerializeField] private Text quest_title;
    [SerializeField] private Text quest_description;
    [SerializeField] private Text first_count_have;
    [SerializeField] private Text first_count_need;
    [SerializeField] private Text second_count_have;
    [SerializeField] private Text second_count_need;
    [SerializeField] private Image first_item_image;
    [SerializeField] private Image second_item_image;
    [SerializeField] private Image win_item_image;
    [SerializeField] private Image quest_complete_button;
    [SerializeField] private Sprite ready_quest_sprite;
    [SerializeField] private Sprite unReady_quest_sprite;
}
