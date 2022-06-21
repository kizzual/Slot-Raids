using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private List<HeroSO> neutralHeroes;
    [SerializeField] private List<HeroSO> undeadHeroes;
    [SerializeField] private List<HeroSO> orderHeroes;
    [SerializeField] private List<HeroSO> demonHeroes;

    [SerializeField] private HeroPanel NeutralHeroes;
    [SerializeField] private HeroPanel UndeadHeroes;
    [SerializeField] private HeroPanel OrderHeroes;
    [SerializeField] private HeroPanel DemonHeroes;


    [SerializeField] private Inventory NeutralInventory; 
    [SerializeField] private Inventory UndeadInventory; 
    [SerializeField] private Inventory OrderInventory; 
    [SerializeField] private Inventory DemonInventory; 
    private List<Hero> _heroes = new List<Hero>();

    public CharacterCharacteristics testq;
    public ScrollingObjects scrollingObjects;
    void Start()
    {
        
    }

    public void Add_NeutralHero()
    {
        int indextHero = UnityEngine.Random.Range(0, neutralHeroes.Count + 1);
        Hero hero = new Hero(neutralHeroes[1]);
        neutralHeroes.RemoveAt(1);
        NeutralHeroes.AddHero(hero);
    }
    public void Add_UndeadHero()
    {
        int indextHero = UnityEngine.Random.Range(0, undeadHeroes.Count + 1);
        Hero hero = new Hero(undeadHeroes[indextHero]);
        undeadHeroes.RemoveAt(indextHero);
        UndeadHeroes.AddHero(hero);
    }
    public void Add_OrderHero()
    {
        int indextHero = UnityEngine.Random.Range(0, orderHeroes.Count + 1);
        Hero hero = new Hero(orderHeroes[indextHero]);
        orderHeroes.RemoveAt(indextHero);
        OrderHeroes.AddHero(hero);
    }
    public void Add_DemonHero()
    {
        int indextHero = UnityEngine.Random.Range(0, demonHeroes.Count + 1);
        Hero hero = new Hero(demonHeroes[indextHero]);
        demonHeroes.RemoveAt(indextHero);
        DemonHeroes.AddHero(hero);
    }
 
    public void test()
    {
        testq.ShowCharacteristics(NeutralHeroes.heroSlots[0].currentHero, scrollingObjects);
    }
    public void test_1()
    {
        gameObject.SetActive(true);
    }

}
