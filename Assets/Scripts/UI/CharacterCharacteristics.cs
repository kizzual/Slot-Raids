using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterCharacteristics : MonoBehaviour
{
    public Image heroImg;
    private ScrollingObjects currentSlot;
    private Hero currentHero;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void ShowCharacteristics(Hero hero, ScrollingObjects slot)
    {
        gameObject.SetActive(true);
        heroImg.sprite = hero.imageRank_1;
        currentSlot = slot;
    }
    public void AddHeroToSlot()
    {
        if (currentSlot != null)
        {
            currentSlot.currentHero = currentHero;
            currentSlot.isActive = true;
            gameObject.SetActive(false);
        }
    }
}
