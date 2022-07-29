using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostUI : MonoBehaviour
{
    [SerializeField] private Image cardImage;
    [SerializeField] private Image manaImg;
    [SerializeField] private GameObject DeactiveButton;
    [SerializeField] private GameObject ActiveButton;
    [SerializeField] private GameObject BoostReady;


    public void ShowCard(BoostCard card)
    {
        cardImage.sprite = card.GetComponent<Image>().sprite;
    }
    public void ActiveteBoostButton(int currentRaids, int requirementRaids)
    {
        if (currentRaids >= requirementRaids)
        {

            DeactiveButton.SetActive(false);
            ActiveButton.SetActive(true);

            BoostReady.SetActive(true);
        }
        else
        {

            DeactiveButton.SetActive(true);
            ActiveButton.SetActive(false);

            BoostReady.SetActive(false);
        }
        float tmp = (float)currentRaids / (float)requirementRaids;
        manaImg.fillAmount = tmp;
    }
    public void ActivaButton_b()
    {
        Debug.Log("TEST   1");
        DeactiveButton.SetActive(false);
        ActiveButton.SetActive(true);
    }
    public void InActiveButton()
    {
        Debug.Log("TEST   2");
        DeactiveButton.SetActive(true);
        ActiveButton.SetActive(false);
    }
}
