using UnityEngine;
using UnityEngine.UI;

public class Sell_UI : MonoBehaviour
{
    [Header("Element sprites")]
    [SerializeField] private Sprite neutral_Icon;
    [SerializeField] private Sprite undead_Icon;
    [SerializeField] private Sprite order_Icon;
    [SerializeField] private Sprite demon_Icon;
    [Space]
    [Header("UI")]
    [SerializeField] private Image element_Logo;
    [SerializeField] private Text item_name;
    [SerializeField] private Text item_rank;
    [SerializeField] private Text item_count;
    [SerializeField] private Image item_icon;
    [SerializeField] private Text current_count;
    [SerializeField] private Text gold_for_selling;

    public void Initialise(Item item, int count,long price)
    {
        switch (item.typeElement)
        {
            case Type_Element.Neutral:
                element_Logo.sprite = neutral_Icon;
                break;
            case Type_Element.Undead:
                element_Logo.sprite = undead_Icon;
                break;
            case Type_Element.Order:
                element_Logo.sprite = order_Icon;
                break;
            case Type_Element.Demon:
                element_Logo.sprite = demon_Icon;
                break;
        }
        switch (item.typeItem)
        {
            case TypeItem.Sword:
                item_name.text = "SWORD";
                break;
            case TypeItem.Shield:
                item_name.text = "SHIELD";
                break;
            case TypeItem.Amulet:
                item_name.text = "AMULET";
                break;
        }
        switch (item.Rank)
        {
            case 1:
                item_rank.text = "RANK 1";
                break;
            case 2:
                item_rank.text = "RANK 2";
                break;
            case 3:
                item_rank.text = "RANK 3";
                break;
        }
        if(count > 0)
            current_count.text = 1.ToString();
        else
            current_count.text = 0.ToString();
        item_count.text = count.ToString();
        item_icon.sprite = item.GetComponent<Image>().sprite;
        gold_for_selling.text = ConvertText.FormatNumb(price);
    }
    public void ChangeCurrentCount(int count, int price)
    {
        current_count.text = count.ToString();
        gold_for_selling.text = ConvertText.FormatNumb(price);
    }
}
