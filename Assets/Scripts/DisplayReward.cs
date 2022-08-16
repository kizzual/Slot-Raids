using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayReward : MonoBehaviour
{
    [SerializeField] private Image reward_image;
    [SerializeField] private Text reward_name;
    [SerializeField] private Sprite slotIcon;
    public void Initialise(Hero hero)
    {
        SoundControl._instance.Reward();
        gameObject.SetActive(true);
        reward_image.sprite = hero.FirstRankSprite;
        reward_image.SetNativeSize();
        reward_name.text = hero.HeroName;
    }
    public void Initialise(Zone zone)
    {
        SoundControl._instance.Reward();
        gameObject.SetActive(true);
        reward_image.sprite = zone.GetComponent<Image>().sprite;
        reward_image.SetNativeSize();
        reward_name.text = zone.nameLocation;
    }
    public void Initialise(BoostCard card)
    {
        SoundControl._instance.Reward();
        gameObject.SetActive(true);
        reward_image.sprite = card.GetComponent<Image>().sprite;
        reward_image.SetNativeSize();
        reward_name.text = "Boost card";
    }
    public void Initialise()
    {
        SoundControl._instance.Reward();
        gameObject.SetActive(true);
        reward_image.sprite = slotIcon;
        reward_image.SetNativeSize();
        reward_name.text = "Raid slot";
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
