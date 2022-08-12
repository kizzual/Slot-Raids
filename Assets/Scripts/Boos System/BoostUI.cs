using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostUI : MonoBehaviour
{
    [SerializeField] private List<Image> cardImage;
    [SerializeField] private Text Timer;
    [SerializeField] private GameObject ChooseCard_panel;
    [SerializeField] private GameObject DeactivateBoostCard_panel;
    [SerializeField] private GameObject BoostReady;
    [SerializeField] private Image CurrentCard;


    public void ShowCard(List<BoostCard> card)
    {
        ChooseCard_panel.SetActive(true);
        DeactivateBoostCard_panel.SetActive(false);
        if(card.Count == 0)
        {
            cardImage[0].gameObject.SetActive(false);
            cardImage[1].gameObject.SetActive(false);
            cardImage[2].gameObject.SetActive(false);
        }
        else if(card.Count == 1)
        {
            cardImage[0].gameObject.SetActive(true);
            cardImage[0].sprite = card[0].GetComponent<Image>().sprite;
            cardImage[1].gameObject.SetActive(false); 
            cardImage[2].gameObject.SetActive(false);
        }
        else if(card.Count == 2)
        {
            cardImage[0].gameObject.SetActive(true);
            cardImage[0].sprite = card[0].GetComponent<Image>().sprite;
            cardImage[1].gameObject.SetActive(true);
            cardImage[1].sprite = card[1].GetComponent<Image>().sprite;
            cardImage[2].gameObject.SetActive(false);
        }
        else
        {
            cardImage[0].gameObject.SetActive(true);
            cardImage[0].sprite = card[0].GetComponent<Image>().sprite;
            cardImage[1].gameObject.SetActive(true);
            cardImage[1].sprite = card[1].GetComponent<Image>().sprite;
            cardImage[2].gameObject.SetActive(true);
            cardImage[2].sprite = card[2].GetComponent<Image>().sprite;
        }   

    }
    public void ShowActiveBoost(float timer, BoostCard currentCard)
    {
        if(!DeactivateBoostCard_panel.activeSelf)
        {
            ChooseCard_panel.SetActive(false);
            DeactivateBoostCard_panel.SetActive(true);
        }
        TimeSpan ts = TimeSpan.FromSeconds(currentCard.TimeDuration - timer);
        Timer.text = ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
    }
    public void SwitchCurrentCardImage(BoostCard card)
    {
        CurrentCard.sprite = card.GetComponent<Image>().sprite;
    }
}
