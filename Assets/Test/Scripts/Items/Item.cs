using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public Type_Element typeElement;
    public TypeItem typeItem;

    public int Selling_price;
    public int Gold_profit;
    public int Protect_profit;
    public int Luck_profit;
    public int Rank;


}
[System.Serializable]
public enum Type_Element
{
    Neutral,
    Undead,
    Order,
    Demon
}

[System.Serializable]
public enum TypeItem
{
    Sword,
    Shield,
    Amulet,
    Gold,
    Death
}

