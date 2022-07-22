using UnityEngine;
using UnityEngine.UI;

public class Panel_UI : MonoBehaviour
{
    [Header("Sprite element")]
    [SerializeField] private Sprite nautral_sprite;
    [SerializeField] private Sprite undead_sprite;
    [SerializeField] private Sprite order_sprite;
    [SerializeField] private Sprite demon_sprite;
    [Space]
    [Header("UI")]
    [SerializeField] private Image Element_logo;
    [SerializeField] private Text Item_name;
    [SerializeField] private Text R_1_count;
    [SerializeField] private Text R_2_count;
    [SerializeField] private Text R_3_count;
    [SerializeField] private Image Rank_1;
    [SerializeField] private Image Rank_2;
    [SerializeField] private Image Rank_3;
    [Space]
    [Header("Check mark")]
    public GameObject Rank_1_mark;
    public GameObject Rank_2_mark;
    public GameObject Rank_3_mark;

    public void DIsplaySwordsInfo(Inventory_controll inventoryControl, Hero hero)
    {

        Item_name.text = "SWORD";
        switch (hero.typeElement)
        {
            case TypeElement.Neutral:
                Element_logo.sprite = nautral_sprite;
                break;
            case TypeElement.Undead:
                Element_logo.sprite = undead_sprite;
                break;
            case TypeElement.Order:
                Element_logo.sprite = order_sprite;
                break;
            case TypeElement.Demon:
                Element_logo.sprite = demon_sprite;
                break;
        }
        switch (hero.Rank)
        {
            case 1:
                {
                    if(inventoryControl.GetSword_count(1, hero.typeElement) > 0)
                        Rank_1.gameObject.SetActive(true);
                    else
                        Rank_1.gameObject.SetActive(false);

                    Rank_2.gameObject.SetActive(false);
                    Rank_3.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    if (inventoryControl.GetSword_count(1, hero.typeElement) > 0)
                        Rank_1.gameObject.SetActive(true);
                    else
                        Rank_1.gameObject.SetActive(false);

                    if (inventoryControl.GetSword_count(2, hero.typeElement) > 0)
                        Rank_2.gameObject.SetActive(true);
                    else
                        Rank_2.gameObject.SetActive(false);

                    Rank_3.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    if (inventoryControl.GetSword_count(1, hero.typeElement) > 0)
                        Rank_1.gameObject.SetActive(true);
                    else
                        Rank_1.gameObject.SetActive(false);

                    if (inventoryControl.GetSword_count(2, hero.typeElement) > 0)
                        Rank_2.gameObject.SetActive(true);
                    else
                        Rank_2.gameObject.SetActive(false);

                    if (inventoryControl.GetSword_count(3, hero.typeElement) > 0)
                        Rank_3.gameObject.SetActive(true);
                    else
                        Rank_3.gameObject.SetActive(false);
                    break;
                }
        }

        if(hero.m_sword != null) 
        {
            if(hero.m_sword.Rank == 1)
            {
                Rank_1.gameObject.SetActive(true);
                Rank_1.sprite = hero.m_sword.GetComponent<Image>().sprite;
            }
            else if(hero.m_sword.Rank == 2)
            {
                Rank_2.gameObject.SetActive(true);

                Rank_2.sprite = hero.m_sword.GetComponent<Image>().sprite;
            }
            else if(hero.m_sword.Rank == 3)
            {
                Rank_3.gameObject.SetActive(true);

                Rank_3.sprite = hero.m_sword.GetComponent<Image>().sprite;
            }
        }
        else
        {
            Rank_1.sprite = inventoryControl.GetSprite_Sword(1, hero.typeElement);
            Rank_2.sprite = inventoryControl.GetSprite_Sword(2, hero.typeElement);
            Rank_3.sprite = inventoryControl.GetSprite_Sword(3, hero.typeElement);
        }
     
        R_1_count.text = inventoryControl.GetSword_count(1, hero.typeElement).ToString();
        R_2_count.text = inventoryControl.GetSword_count(2, hero.typeElement).ToString();
        R_3_count.text = inventoryControl.GetSword_count(3, hero.typeElement).ToString();
        CheckHeroCurrentItem_sword(hero);
    }
    public void DIsplayShieldsInfo(Inventory_controll inventoryControl, Hero hero)
    {
        Item_name.text = "SHIELD";
        switch (hero.typeElement)
        {
            case TypeElement.Neutral:
                Element_logo.sprite = nautral_sprite;
                break;
            case TypeElement.Undead:
                Element_logo.sprite = undead_sprite;
                break;
            case TypeElement.Order:
                Element_logo.sprite = order_sprite;
                break;
            case TypeElement.Demon:
                Element_logo.sprite = demon_sprite;
                break;
        }
        switch (hero.Rank)
        {
            case 1:
                {
                    if (inventoryControl.GetShield_count(1, hero.typeElement) > 0)
                        Rank_1.gameObject.SetActive(true);
                    else
                        Rank_1.gameObject.SetActive(false);

                    Rank_2.gameObject.SetActive(false);
                    Rank_3.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    if (inventoryControl.GetShield_count(1, hero.typeElement) > 0)
                        Rank_1.gameObject.SetActive(true);
                    else
                        Rank_1.gameObject.SetActive(false);

                    if (inventoryControl.GetShield_count(2, hero.typeElement) > 0)
                        Rank_2.gameObject.SetActive(true);
                    else
                        Rank_2.gameObject.SetActive(false);

                    Rank_3.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    if (inventoryControl.GetShield_count(1, hero.typeElement) > 0)
                        Rank_1.gameObject.SetActive(true);
                    else
                        Rank_1.gameObject.SetActive(false);

                    if (inventoryControl.GetShield_count(2, hero.typeElement) > 0)
                        Rank_2.gameObject.SetActive(true);
                    else
                        Rank_2.gameObject.SetActive(false);

                    if (inventoryControl.GetShield_count(3, hero.typeElement) > 0)
                        Rank_3.gameObject.SetActive(true);
                    else
                        Rank_3.gameObject.SetActive(false);
                    break;
                }
        }

        if (hero.m_shield != null)
        {
            if (hero.m_shield.Rank == 1)
            {
                Rank_1.gameObject.SetActive(true);
                Rank_1.sprite = hero.m_shield.GetComponent<Image>().sprite;
            }
            else if (hero.m_shield.Rank == 2)
            {
                Rank_2.gameObject.SetActive(true);
                Rank_2.sprite = hero.m_shield.GetComponent<Image>().sprite;
            }
            else if (hero.m_shield.Rank == 3)
            {
                Rank_3.gameObject.SetActive(true);
                Rank_3.sprite = hero.m_shield.GetComponent<Image>().sprite;
            }
        }
        else
        {
            Rank_1.sprite = inventoryControl.GetSprite_Shield(1, hero.typeElement);
            Rank_2.sprite = inventoryControl.GetSprite_Shield(2, hero.typeElement);
            Rank_3.sprite = inventoryControl.GetSprite_Shield(3, hero.typeElement);
        }
       

        R_1_count.text = inventoryControl.GetShield_count(1, hero.typeElement).ToString();
        R_2_count.text = inventoryControl.GetShield_count(2, hero.typeElement).ToString();
        R_3_count.text = inventoryControl.GetShield_count(3, hero.typeElement).ToString();
        CheckHeroCurrentItem_shield(hero);
    }
    public void DIsplayAmuletInfo(Inventory_controll inventoryControl, Hero hero)
    {
        Item_name.text = "AMULET";
        switch (hero.typeElement)
        {
            case TypeElement.Neutral:
                Element_logo.sprite = nautral_sprite;
                break;
            case TypeElement.Undead:
                Element_logo.sprite = undead_sprite;
                break;
            case TypeElement.Order:
                Element_logo.sprite = order_sprite;
                break;
            case TypeElement.Demon:
                Element_logo.sprite = demon_sprite;
                break;
        }
        switch (hero.Rank)
        {
            case 1:
                {
                    if (inventoryControl.GetAmulet_count(1, hero.typeElement) > 0)
                        Rank_1.gameObject.SetActive(true);
                    else
                        Rank_1.gameObject.SetActive(false);

                    Rank_2.gameObject.SetActive(false);
                    Rank_3.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    if (inventoryControl.GetAmulet_count(1, hero.typeElement) > 0)
                        Rank_1.gameObject.SetActive(true);
                    else
                        Rank_1.gameObject.SetActive(false);

                    if (inventoryControl.GetAmulet_count(2, hero.typeElement) > 0)
                        Rank_2.gameObject.SetActive(true);
                    else
                        Rank_2.gameObject.SetActive(false);

                    Rank_3.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    if (inventoryControl.GetAmulet_count(1, hero.typeElement) > 0)
                        Rank_1.gameObject.SetActive(true);
                    else
                        Rank_1.gameObject.SetActive(false);

                    if (inventoryControl.GetAmulet_count(2, hero.typeElement) > 0)
                        Rank_2.gameObject.SetActive(true);
                    else
                        Rank_2.gameObject.SetActive(false);

                    if (inventoryControl.GetAmulet_count(3, hero.typeElement) > 0)
                        Rank_3.gameObject.SetActive(true);
                    else
                        Rank_3.gameObject.SetActive(false);
                    break;
                }
        }
        if (hero.m_amulet != null)
        {
            if (hero.m_amulet.Rank == 1)
            {
                Rank_1.gameObject.SetActive(true);
                Rank_1.sprite = hero.m_amulet.GetComponent<Image>().sprite;
            }
            else if (hero.m_amulet.Rank == 2)
            {
                Rank_2.gameObject.SetActive(true);
                Rank_2.sprite = hero.m_amulet.GetComponent<Image>().sprite;
            }
            else if (hero.m_amulet.Rank == 3)
            {
                Rank_3.gameObject.SetActive(true);
                Rank_3.sprite = hero.m_amulet.GetComponent<Image>().sprite;
            }
        }
        else
        {
            Rank_1.sprite = inventoryControl.GetSprite_Amulet(1, hero.typeElement);
            Rank_2.sprite = inventoryControl.GetSprite_Amulet(2, hero.typeElement);
            Rank_3.sprite = inventoryControl.GetSprite_Amulet(3, hero.typeElement);
        }
        R_1_count.text = inventoryControl.GetAmulet_count(1, hero.typeElement).ToString();
        R_2_count.text = inventoryControl.GetAmulet_count(2, hero.typeElement).ToString();
        R_3_count.text = inventoryControl.GetAmulet_count(3, hero.typeElement).ToString();
        CheckHeroCurrentItem_amulet(hero);
    }
    private void CheckHeroCurrentItem_sword(Hero hero)
    {
        Item tmpItem = hero.GetItem_Sword();
        if (tmpItem != null)
        {
            if(tmpItem.Rank == 1)
            {
                Rank_1_mark.SetActive(true);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(false);
            }
            else if ( tmpItem.Rank == 2)
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(true);
                Rank_3_mark.SetActive(false);
            }
            else if(tmpItem.Rank == 3)
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(true);
            }
        }
        else
        {
            Rank_1_mark.SetActive(false);
            Rank_2_mark.SetActive(false);
            Rank_3_mark.SetActive(false);
        }
    }
    private void CheckHeroCurrentItem_shield(Hero hero)
    {
        Item tmpItem = hero.GetItem_Shield();
        if (tmpItem != null)
        {
            if (tmpItem.Rank == 1)
            {
                Rank_1_mark.SetActive(true);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(false);
            }
            else if (tmpItem.Rank == 2)
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(true);
                Rank_3_mark.SetActive(false);
            }
            else if (tmpItem.Rank == 3)
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(true);
            }
        }
        else
        {
            Rank_1_mark.SetActive(false);
            Rank_2_mark.SetActive(false);
            Rank_3_mark.SetActive(false);
        }
    }
    private void CheckHeroCurrentItem_amulet(Hero hero)
    {
        Item tmpItem = hero.GetItem_Amulet();
        if (tmpItem != null)
        {
            if (tmpItem.Rank == 1)
            {
                Rank_1_mark.SetActive(true);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(false);
            }
            else if (tmpItem.Rank == 2)
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(true);
                Rank_3_mark.SetActive(false);
            }
            else if (tmpItem.Rank == 3)
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(true);
            }
        }
        else
        {
            Rank_1_mark.SetActive(false);
            Rank_2_mark.SetActive(false);
            Rank_3_mark.SetActive(false);
        }
    }

    public void SetMark(int markIndex)
    {
        if(markIndex == 1)
        {
            if(!Rank_1_mark.activeSelf)
            {
                Rank_1_mark.SetActive(true);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(false);
            }
            else
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(false);
            }
           
        }
        else if(markIndex == 2)
        {
            if (!Rank_2_mark.activeSelf)
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(true);
                Rank_3_mark.SetActive(false);
            }
            else
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(false);
            }
        }
        else if (markIndex == 3)
        {
            if (!Rank_3_mark.activeSelf)
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(true);
            }
            else
            {
                Rank_1_mark.SetActive(false);
                Rank_2_mark.SetActive(false);
                Rank_3_mark.SetActive(false);
            }
        }
    }
}
