using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prize : MonoBehaviour
{
    [SerializeField] public Type _Type;
    public Type type;
    [SerializeField] public ElementType _ElementType;
    public ElementType elementType;
    public int goldPrize;
    public int profitPercent;
    public int defencePercent;
    public int luckPercent;
    private RectTransform currentPosition;
    public Sprite sprite;
    private Image Image;

    void Start()
    {
        currentPosition = GetComponent<RectTransform>();
        Image = GetComponent<Image>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
     
        //    var parent = GetComponentInParent<RotatingObject>();
       //     parent.prize = this;

        
    }
    public void SwitchPosition(Vector3 newPosition)
    {
        currentPosition.transform.localPosition = newPosition;
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

    public void TakeInfo(Prize prize)
    {
        _Type = prize._Type;
        goldPrize = prize.goldPrize;
        profitPercent = prize.profitPercent;
        defencePercent = prize.defencePercent;
        luckPercent = prize.luckPercent;
        name = prize.name;
        Image.sprite = prize.sprite;

    }

}
public enum Type
{
    gold_1,
    gold_2,
    gold_3,
    death,
    item_sword_1,
    item_sword_2,
    item_sword_3,
    item_shield_1,
    item_shield_2,
    item_shield_3,
    item_amulet_1,
    item_amulet_2,
    item_amulet_3,
    item_egg_neutral,
    item_egg_undead,
    item_egg_order,
    item_egg_demons,
}
public enum ElementType
{
    Neutral,
    Undead,
    Order,
    Demon
}

