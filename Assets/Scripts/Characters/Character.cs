using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private List<HeroSO> heroesSo;
    [SerializeField] private HeroPanel NeutralHeroes;
    [SerializeField] private HeroPanel UndeadHeroes;
    [SerializeField] private HeroPanel OrderHeroes;
    [SerializeField] private HeroPanel DemonHeroes;


    [SerializeField] private Inventory NeutralInventory; 
    [SerializeField] private Inventory UndeadInventory; 
    [SerializeField] private Inventory OrderInventory; 
    [SerializeField] private Inventory DemonInventory; 
    private List<Hero> _heroes = new List<Hero>();


    void Start()
    {
        
    }



    public void AddHero()
    {
        var hero = new Hero(1, 10, 12, 6, 1);
        _heroes.Add(hero);
    }
    public void OpenNeutralEgg()
    {

    }

}
