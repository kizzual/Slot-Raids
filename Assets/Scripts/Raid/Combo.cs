using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combo : MonoBehaviour
{
    [SerializeField] private Inventory_controll inventory_Controll;
    [SerializeField] private Raid_control raid_Control;
    [SerializeField] private Boost_Controll boost_Controll;
    [SerializeField] private FullParticlesToInv fullParticlesToInv;
    public enum ComboType
    {
        first,
        second,
        third,
        fourth,
        fifth,
        sixth,
        seventh,
        eighth,
        ninth
    }
    public ComboType comboType;

    [SerializeField] private List<TextMeshProUGUI> textCombo;
    [SerializeField] private GameObject FullCombo;
    [SerializeField] private GameObject LineCombo;
    [SerializeField] private QuestControll questControll;

    [Header("3lvl")]
    [SerializeField] private GameObject firstH3;
    [SerializeField] private GameObject firstV3;
    [SerializeField] private GameObject secondV3;
    [Header("4lvl")]
    [SerializeField] private GameObject firstH4;
    [SerializeField] private GameObject secondH4;
    [SerializeField] private GameObject firstV4;
    [SerializeField] private GameObject secondV4;
    [Header("5lvl")]
    [SerializeField] private GameObject firstH5;
    [SerializeField] private GameObject leftSecondH5;
    [SerializeField] private GameObject rightSecondH5;
    [SerializeField] private GameObject middleV5;
    [Header("6lvl")]
    [SerializeField] private GameObject firstH6;
    [SerializeField] private GameObject secondH6;
    [SerializeField] private GameObject leftV6;
    [SerializeField] private GameObject middleV6;
    [SerializeField] private GameObject rightV6;
    [Header("7lvl")]
    [SerializeField] private GameObject firstH7;
    [SerializeField] private GameObject secondH7;
    [SerializeField] private GameObject leftV7;
    [SerializeField] private GameObject middleV7;
    [SerializeField] private GameObject rightV7;
    [SerializeField] private GameObject middleV3;
    [Header("8lvl")]
    [SerializeField] private GameObject firstH8;
    [SerializeField] private GameObject secondH8;
    [SerializeField] private GameObject thirdH8;
    [SerializeField] private GameObject leftV8;
    [SerializeField] private GameObject middleV8;
    [SerializeField] private GameObject rightV8;
    [Header("9lvl")]
    [SerializeField] private GameObject firstH9;
    [SerializeField] private GameObject secondH9;
    [SerializeField] private GameObject thirdH9;
    [SerializeField] private GameObject firstV9;
    [SerializeField] private GameObject secondV9;
    [SerializeField] private GameObject thirdV9;
    [SerializeField] private GameObject diagonallyUpToDown;
    [SerializeField] private GameObject diagonallyDonwToUp;
    private int m_boostGold = 1;
    private int m_boostItem = 1;
    private float m_timer = 0;
    private bool m_isCombo;
    private void Update()
    {
       
        if (m_isCombo)
        {
            m_timer += Time.fixedDeltaTime;
            if (m_timer >= 1.5f)
            {
                m_isCombo = false;
                m_timer = 0;
                DeactivateCombo();
            }
        }
    }
    public void DeactivateCombo()
    {
        if(comboType == ComboType.second)
        {
            if (FullCombo.activeSelf)
                FullCombo.SetActive(false);
        }
        else if (comboType == ComboType.third)
        {
            if (FullCombo.activeSelf)
                FullCombo.SetActive(false);
            if (LineCombo.activeSelf)
                LineCombo.SetActive(false);
            if (firstH3.activeSelf)
                firstH3.SetActive(false);
            if (firstV3.activeSelf)
                firstV3.SetActive(false);
            if (secondV3.activeSelf)
                secondV3.SetActive(false);
        }
        else if(comboType == ComboType.fourth)
        {
            if (FullCombo.activeSelf)
                FullCombo.SetActive(false);
            if (LineCombo.activeSelf)
                LineCombo.SetActive(false);
            if (firstH4.activeSelf)
                firstH4.SetActive(false);
            if (secondH4.activeSelf)
                secondH4.SetActive(false);
            if (firstV4.activeSelf)
                firstV4.SetActive(false);
            if (secondV4.activeSelf)
                secondV4.SetActive(false);
        }
        else if(comboType == ComboType.fifth)
        {
            if (FullCombo.activeSelf)
                FullCombo.SetActive(false);
            if (LineCombo.activeSelf)
                LineCombo.SetActive(false);
            if (firstH5.activeSelf)
                firstH5.SetActive(false);
            if (leftSecondH5.activeSelf)
                leftSecondH5.SetActive(false);
            if (rightSecondH5.activeSelf)
                rightSecondH5.SetActive(false);
            if (middleV5.activeSelf)
                middleV5.SetActive(false);
        }
        else if(comboType == ComboType.sixth)
        {
            if (FullCombo.activeSelf)
                FullCombo.SetActive(false);
            if (LineCombo.activeSelf)
                LineCombo.SetActive(false);
            if (firstH6.activeSelf)
                firstH6.SetActive(false);
            if (secondH6.activeSelf)
                secondH6.SetActive(false);
            if (leftV6.activeSelf)
                leftV6.SetActive(false);
            if (middleV6.activeSelf)
                middleV6.SetActive(false);
            if (rightV6.activeSelf)
                rightV6.SetActive(false);
        }
        else if(comboType == ComboType.seventh)
        {
            if (FullCombo.activeSelf)
                FullCombo.SetActive(false);
            if (LineCombo.activeSelf)
                LineCombo.SetActive(false);
            if (firstH7.activeSelf)
                firstH7.SetActive(false);
            if (secondH7.activeSelf)
                secondH7.SetActive(false);
            if (leftV7.activeSelf)
                leftV7.SetActive(false);
            if (middleV7.activeSelf)
                middleV7.SetActive(false);
            if (rightV7.activeSelf)
                rightV7.SetActive(false);
            if (rightV7.activeSelf)
                rightV7.SetActive(false);
        }
        else if (comboType == ComboType.eighth)
        {
            if (FullCombo.activeSelf)
                FullCombo.SetActive(false);
            if (LineCombo.activeSelf)
                LineCombo.SetActive(false);
            if (firstH8.activeSelf)
                firstH8.SetActive(false);
            if (secondH8.activeSelf)
                secondH8.SetActive(false);
            if (thirdH8.activeSelf)
                thirdH8.SetActive(false);
            if (leftV8.activeSelf)
                leftV8.SetActive(false);
            if (middleV8.activeSelf)
                middleV8.SetActive(false);
            if (rightV8.activeSelf)
                rightV8.SetActive(false);
        }
        else if (comboType == ComboType.ninth)
        {
            if (FullCombo.activeSelf)
                FullCombo.SetActive(false);
            if (LineCombo.activeSelf)
                LineCombo.SetActive(false);
            if (firstH9.activeSelf)
                firstH9.SetActive(false);
            if (secondH9.activeSelf)
                secondH9.SetActive(false);
            if (thirdH9.activeSelf)
                thirdH9.SetActive(false);
            if (firstV9.activeSelf)
                firstV9.SetActive(false);
            if (secondV9.activeSelf)
                secondV9.SetActive(false);
            if (thirdV9.activeSelf)
                thirdV9.SetActive(false);
            if (diagonallyUpToDown.activeSelf)
                diagonallyUpToDown.SetActive(false);
            if (diagonallyDonwToUp.activeSelf)
                diagonallyDonwToUp.SetActive(false);
        }
    }
    
    public void CheckCombo(List<Raid_UI> slots, Raid_control raidControl)
    {
        if (comboType != ComboType.first)
        {
            long winGold = 0;
            int comboFull = 0;
            List<Item> winItems = new List<Item>();
            if (CheckFullCombo(slots))
            {
                // фул комбо 
                for (int i = 0; i < slots.Count; i++)
                {
                    if (slots[i].isOpened && slots[i].m_currentHero != null)
                    {
                        if (slots[i].GetDice().prize == DiceControll.Prize.Item)
                        {
                            for (int j = 0; j < m_boostItem; j++)
                            {
                                winItems.Add(slots[i].GetDice().winItem);
                            }
                            raidControl.GetParticles().PlayParticleWitItem(i, slots[i].GetDice().winItem);
                            winGold += slots[i].m_currentHero.GetGoldProfit() * slots[i].m_currentHero.GetCombo();
                        }
                        else if (slots[i].GetDice().prize == DiceControll.Prize.Gold)
                        {
                            winGold += slots[i].m_currentHero.GetNeutralGold() * slots[i].m_currentHero.GetCombo();
                            raidControl.GetParticles().PlayParticleWitoutItem(i);
                        }
                        comboFull += slots[i].m_currentHero.GetCombo();
                    }

                }
                foreach (var item in textCombo)
                {
                    item.text = "X" + comboFull.ToString();
                }

                SoundControl._instance.Combo();
                Gold.AddGold(winGold * m_boostGold);

                GoldAwarding(winGold * m_boostGold);
                ItemsAwarding(winItems);
                StartCoroutine(fullparticle(winItems, winGold * m_boostGold));
                FullCombo.SetActive(true);
                m_isCombo = true;
               
            }
            else
            {
                for (int i = 0; i < slots.Count; i++)
                {
                    if (slots[i].isOpened && slots[i].m_currentHero != null)
                    {

                        if (slots[i].GetDice().prize == DiceControll.Prize.Item)
                        {
                            for (int j = 0; j < m_boostItem; j++)
                            {
                                winItems.Add(slots[i].GetDice().winItem);
                            }
                            raidControl.GetParticles().PlayParticleWitItem(i, slots[i].GetDice().winItem);
                            winGold += slots[i].m_currentHero.GetGoldProfit();
                        }
                        else if (slots[i].GetDice().prize == DiceControll.Prize.Gold)
                        {
                            winGold += slots[i].m_currentHero.GetNeutralGold();
                            raidControl.GetParticles().PlayParticleWitoutItem(i);
                        }
                    }

                }
                if(comboType == ComboType.second)
                {
                    Gold.AddGold(winGold * m_boostGold);
                    GoldAwarding(winGold * m_boostGold);
                    ItemsAwarding(winItems);
                    StartCoroutine(fullparticle(winItems, winGold * m_boostGold));

                }
                else if (comboType == ComboType.third)
                {
                    bool isCombo = false;
                    int totalCombo = 0;
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[1].isOpened && slots[1].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[1].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[1].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[1].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[1].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            firstH3.SetActive(true);
                        }
                    }
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[2].isOpened && slots[2].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[2].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[2].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            firstV3.SetActive(true);
                        }
                    }
                    if (slots[1].isOpened && slots[1].m_currentHero != null &&
                       slots[2].isOpened && slots[2].m_currentHero != null)
                    {
                        if (slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[2].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[1].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[1].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[2].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            secondV3.SetActive(true);
                        }
                    }
                    if (isCombo)
                    {
                        m_isCombo = true;
                        SoundControl._instance.Combo();
                    }
                    foreach (var item in textCombo)
                    {
                        item.text = "X" + totalCombo.ToString();
                    }

                    Gold.AddGold(winGold * m_boostGold);
                    GoldAwarding(winGold * m_boostGold);
                    ItemsAwarding(winItems);
                    StartCoroutine(fullparticle(winItems, winGold * m_boostGold));
                }
                else if (comboType == ComboType.fourth)
                {
                    bool isCombo = false;
                    int totalCombo = 0;

                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[1].isOpened && slots[1].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[1].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[1].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[1].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[1].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            firstH4.SetActive(true);
                        }
                    }
                    if (slots[3].isOpened && slots[3].m_currentHero != null &&
                        slots[2].isOpened && slots[2].m_currentHero != null)
                    {
                        if (slots[3].GetDice().prize == DiceControll.Prize.Item &&
                            slots[2].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[3].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[3].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[3].GetDice().winItem);
                            winItems.Add(slots[2].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            secondH4.SetActive(true);
                        }
                    }
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                       slots[2].isOpened && slots[2].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[2].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[2].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            firstV4.SetActive(true);
                        }
                    }
                    if (slots[1].isOpened && slots[1].m_currentHero != null &&
                      slots[3].isOpened && slots[3].m_currentHero != null)
                    {
                        if (slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[3].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[1].m_currentHero.GetCombo() + slots[3].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[1].m_currentHero.GetGoldProfit() + slots[3].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[3].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            secondV4.SetActive(true);
                        }
                    }
                    if (isCombo)
                    {
                        m_isCombo = true;
                        SoundControl._instance.Combo();
                    }
                    foreach (var item in textCombo)
                    {
                        item.text = "X" + totalCombo.ToString();
                    }

                    Gold.AddGold(winGold * m_boostGold);
                    GoldAwarding(winGold * m_boostGold);
                    ItemsAwarding(winItems);
                    StartCoroutine(fullparticle(winItems, winGold * m_boostGold));
                }
                else if (comboType == ComboType.fifth)
                {
                    bool isCombo = false;
                    int totalCombo = 0;

                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[1].isOpened && slots[1].m_currentHero != null &&
                        slots[2].isOpened && slots[2].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[2].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[1].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[1].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[2].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            firstH5.SetActive(true);
                        }
                    }
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[3].isOpened && slots[3].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[3].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[3].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[3].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[3].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            leftSecondH5.SetActive(true);
                        }
                    }
                    if (slots[2].isOpened && slots[2].m_currentHero != null &&
                       slots[3].isOpened && slots[3].m_currentHero != null &&
                       slots[4].isOpened && slots[4].m_currentHero != null)
                    {
                        if (slots[2].GetDice().prize == DiceControll.Prize.Item &&
                            slots[3].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[2].m_currentHero.GetCombo() + slots[3].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[2].m_currentHero.GetGoldProfit() + slots[3].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[2].GetDice().winItem);
                            winItems.Add(slots[3].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            rightSecondH5.SetActive(true);
                        }
                    }
                    if (slots[1].isOpened && slots[1].m_currentHero != null &&
                      slots[3].isOpened && slots[3].m_currentHero != null &&
                      slots[4].isOpened && slots[4].m_currentHero != null)
                    {
                        if (slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[3].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[1].m_currentHero.GetCombo() + slots[3].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[1].m_currentHero.GetGoldProfit() + slots[3].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[3].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            middleV5.SetActive(true);
                        }
                    }
                    if (isCombo)
                    {
                        m_isCombo = true;
                        SoundControl._instance.Combo();
                    }
                    foreach (var item in textCombo)
                    {
                        item.text = "X" + totalCombo.ToString();
                    }

                    Gold.AddGold(winGold * m_boostGold);
                    GoldAwarding(winGold * m_boostGold);
                    ItemsAwarding(winItems);
                    StartCoroutine(fullparticle(winItems, winGold * m_boostGold));
                }
                else if (comboType == ComboType.sixth)
                {
                    bool isCombo = false;
                    int totalCombo = 0;

                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[1].isOpened && slots[1].m_currentHero != null &&
                        slots[2].isOpened && slots[2].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[2].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[1].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[1].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[2].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            firstH6.SetActive(true);
                        }
                    }
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[3].isOpened && slots[3].m_currentHero != null)

                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[3].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[3].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[3].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[3].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            leftV6.SetActive(true);
                        }
                    }
                    if (slots[2].isOpened && slots[2].m_currentHero != null &&
                       slots[5].isOpened && slots[4].m_currentHero != null)
                    {
                        if (slots[2].GetDice().prize == DiceControll.Prize.Item &&
                            slots[5].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[2].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[2].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[2].GetDice().winItem);
                            winItems.Add(slots[5].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            rightV6.SetActive(true);
                        }
                    }
                    if (slots[1].isOpened && slots[1].m_currentHero != null &&
                      slots[4].isOpened && slots[4].m_currentHero != null)
                    {
                        if (slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[1].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[1].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            middleV6.SetActive(true);
                        }
                    }
                    if (slots[3].isOpened && slots[3].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null &&
                        slots[5].isOpened && slots[5].m_currentHero != null)
                    {
                        if (slots[3].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item &&
                            slots[5].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[3].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[3].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[3].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            winItems.Add(slots[5].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            secondH6.SetActive(true);
                        }
                    }

                    if (isCombo)
                    {
                        m_isCombo = true;
                        SoundControl._instance.Combo();
                    }
                    foreach (var item in textCombo)
                    {
                        item.text = "X" + totalCombo.ToString();
                    }

                    Gold.AddGold(winGold * m_boostGold);
                    GoldAwarding(winGold * m_boostGold);
                    ItemsAwarding(winItems);
                    StartCoroutine(fullparticle(winItems, winGold * m_boostGold));
                }
                else if (comboType == ComboType.seventh)
                {
                    bool isCombo = false;
                    int totalCombo = 0;

                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[1].isOpened && slots[1].m_currentHero != null &&
                        slots[2].isOpened && slots[2].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[2].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[1].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[1].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[2].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            firstH7.SetActive(true);
                        }
                    }
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[3].isOpened && slots[3].m_currentHero != null)

                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[3].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[3].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[3].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[3].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            leftV7.SetActive(true);
                        }
                    }
                    if (slots[2].isOpened && slots[2].m_currentHero != null &&
                       slots[5].isOpened && slots[4].m_currentHero != null)
                    {
                        if (slots[2].GetDice().prize == DiceControll.Prize.Item &&
                            slots[5].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[2].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[2].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[2].GetDice().winItem);
                            winItems.Add(slots[5].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            rightV7.SetActive(true);
                        }
                    }
                    if (slots[1].isOpened && slots[1].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null)
                    {
                        if (slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[1].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[1].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            middleV7.SetActive(true);
                        }
                    }
                    if (slots[3].isOpened && slots[3].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null &&
                        slots[5].isOpened && slots[5].m_currentHero != null)
                    {
                        if (slots[3].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item &&
                            slots[5].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[3].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[3].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[3].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            winItems.Add(slots[5].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            secondH7.SetActive(true);
                        }
                    }
                    if (slots[1].isOpened && slots[3].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null &&
                        slots[6].isOpened && slots[6].m_currentHero != null)
                    {
                        if (slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item &&
                            slots[6].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[1].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[6].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[1].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[6].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            winItems.Add(slots[6].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            middleV3.SetActive(true);
                        }
                    }



                    if (isCombo)
                    {
                        m_isCombo = true;
                        SoundControl._instance.Combo();
                    }
                    foreach (var item in textCombo)
                    {
                        item.text = "X" + totalCombo.ToString();
                    }

                    Gold.AddGold(winGold * m_boostGold);
                    GoldAwarding(winGold * m_boostGold);
                    ItemsAwarding(winItems);
                    StartCoroutine(fullparticle(winItems, winGold * m_boostGold));
                }
                else if (comboType == ComboType.eighth)
                {
                    bool isCombo = false;
                    int totalCombo = 0;
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[1].isOpened && slots[1].m_currentHero != null &&
                        slots[2].isOpened && slots[2].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[2].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[1].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[1].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[2].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            firstH8.SetActive(true);
                        }
                    }
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[3].isOpened && slots[3].m_currentHero != null &&
                        slots[6].isOpened && slots[6].m_currentHero != null)

                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[3].GetDice().prize == DiceControll.Prize.Item &&
                            slots[6].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[3].m_currentHero.GetCombo() + slots[6].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[3].m_currentHero.GetGoldProfit() + slots[6].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[3].GetDice().winItem);
                            winItems.Add(slots[6].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            leftV8.SetActive(true);
                        }
                    }
                    if (slots[2].isOpened && slots[2].m_currentHero != null &&
                       slots[5].isOpened && slots[4].m_currentHero != null &&
                       slots[7].isOpened && slots[7].m_currentHero != null)
                    {
                        if (slots[2].GetDice().prize == DiceControll.Prize.Item &&
                            slots[5].GetDice().prize == DiceControll.Prize.Item &&
                            slots[7].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[2].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo() + slots[7].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[2].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit() + slots[7].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[2].GetDice().winItem);
                            winItems.Add(slots[5].GetDice().winItem);
                            winItems.Add(slots[7].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            rightV8.SetActive(true);
                        }
                    }
                    if (slots[1].isOpened && slots[1].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null)
                    {
                        if (slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[1].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[1].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            middleV8.SetActive(true);
                        }
                    }
                    if (slots[3].isOpened && slots[3].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null &&
                        slots[5].isOpened && slots[5].m_currentHero != null)
                    {
                        if (slots[3].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item &&
                            slots[5].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[3].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[3].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[3].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            winItems.Add(slots[5].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            secondH8.SetActive(true);
                        }
                    }
                    if (slots[6].isOpened && slots[6].m_currentHero != null &&
                        slots[7].isOpened && slots[7].m_currentHero != null)
                    {
                        if (slots[6].GetDice().prize == DiceControll.Prize.Item &&
                            slots[7].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[6].m_currentHero.GetCombo() + slots[7].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[6].m_currentHero.GetGoldProfit() + slots[7].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[6].GetDice().winItem);
                            winItems.Add(slots[7].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            thirdH8.SetActive(true);
                        }
                    }



                    if (isCombo)
                    {
                        m_isCombo = true;
                        SoundControl._instance.Combo();
                    }
                    foreach (var item in textCombo)
                    {
                        item.text = "X" + totalCombo.ToString();
                    }
                    Gold.AddGold(winGold * m_boostGold);
                    GoldAwarding(winGold * m_boostGold);
                    ItemsAwarding(winItems);
                    StartCoroutine(fullparticle(winItems, winGold * m_boostGold));
                }
                else if (comboType == ComboType.ninth)
                {
                    bool isCombo = false;
                    int totalCombo = 0;
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[1].isOpened && slots[1].m_currentHero != null &&
                        slots[2].isOpened && slots[2].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[2].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[1].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[1].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[2].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            firstH9.SetActive(true);
                        }
                    }
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[3].isOpened && slots[3].m_currentHero != null &&
                        slots[6].isOpened && slots[6].m_currentHero != null)

                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[3].GetDice().prize == DiceControll.Prize.Item &&
                            slots[6].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[3].m_currentHero.GetCombo() + slots[6].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[3].m_currentHero.GetGoldProfit() + slots[6].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[3].GetDice().winItem);
                            winItems.Add(slots[6].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            firstV9.SetActive(true);
                        }
                    }
                    if (slots[2].isOpened && slots[2].m_currentHero != null &&
                       slots[5].isOpened && slots[4].m_currentHero != null &&
                       slots[8].isOpened && slots[8].m_currentHero != null)
                    {
                        if (slots[2].GetDice().prize == DiceControll.Prize.Item &&
                            slots[5].GetDice().prize == DiceControll.Prize.Item &&
                            slots[8].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[2].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo() + slots[8].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[2].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit() + slots[8].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[2].GetDice().winItem);
                            winItems.Add(slots[5].GetDice().winItem);
                            winItems.Add(slots[8].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            thirdV9.SetActive(true);
                        }
                    }
                    if (slots[3].isOpened && slots[3].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null &&
                        slots[5].isOpened && slots[5].m_currentHero != null)
                    {
                        if (slots[3].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item &&
                            slots[5].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[3].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[5].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[3].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[5].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[3].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            winItems.Add(slots[5].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            secondH9.SetActive(true);
                        }
                    }
                    if (slots[1].isOpened && slots[1].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null &&
                        slots[7].isOpened && slots[7].m_currentHero != null)
                    {
                        if (slots[1].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item &&
                            slots[7].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[1].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[7].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[1].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[7].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[1].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            winItems.Add(slots[7].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            secondV9.SetActive(true);
                        }
                    }
                    if (slots[6].isOpened && slots[6].m_currentHero != null &&
                        slots[7].isOpened && slots[7].m_currentHero != null &&
                        slots[8].isOpened && slots[8].m_currentHero != null)
                    {
                        if (slots[6].GetDice().prize == DiceControll.Prize.Item &&
                            slots[7].GetDice().prize == DiceControll.Prize.Item &&
                            slots[8].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[6].m_currentHero.GetCombo() + slots[7].m_currentHero.GetCombo() + slots[8].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[6].m_currentHero.GetGoldProfit() + slots[7].m_currentHero.GetGoldProfit() + slots[8].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[6].GetDice().winItem);
                            winItems.Add(slots[7].GetDice().winItem);
                            winItems.Add(slots[8].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            thirdH9.SetActive(true);
                        }
                    }
                    if (slots[0].isOpened && slots[0].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null &&
                        slots[8].isOpened && slots[8].m_currentHero != null)
                    {
                        if (slots[0].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item &&
                            slots[8].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[0].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[8].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[0].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[8].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[0].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            winItems.Add(slots[8].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            diagonallyUpToDown.SetActive(true);
                        }
                    }
                    if (slots[6].isOpened && slots[6].m_currentHero != null &&
                        slots[4].isOpened && slots[4].m_currentHero != null &&
                        slots[2].isOpened && slots[2].m_currentHero != null)
                    {
                        if (slots[6].GetDice().prize == DiceControll.Prize.Item &&
                            slots[4].GetDice().prize == DiceControll.Prize.Item &&
                            slots[2].GetDice().prize == DiceControll.Prize.Item)
                        {
                            int combo = slots[6].m_currentHero.GetCombo() + slots[4].m_currentHero.GetCombo() + slots[2].m_currentHero.GetCombo();
                            totalCombo += combo;
                            long totalComgoGold = slots[6].m_currentHero.GetGoldProfit() + slots[4].m_currentHero.GetGoldProfit() + slots[2].m_currentHero.GetGoldProfit();
                            totalComgoGold *= combo;
                            winGold += totalComgoGold;
                            winItems.Add(slots[6].GetDice().winItem);
                            winItems.Add(slots[4].GetDice().winItem);
                            winItems.Add(slots[2].GetDice().winItem);
                            isCombo = true;
                            LineCombo.SetActive(true);
                            diagonallyDonwToUp.SetActive(true);
                        }
                    }



                    if (isCombo)
                    {
                        m_isCombo = true;
                        SoundControl._instance.Combo();
                    }
                    foreach (var item in textCombo)
                    {
                        item.text = "X" + totalCombo.ToString();
                    }
                    Gold.AddGold(winGold * m_boostGold);
                    GoldAwarding(winGold * m_boostGold);
                    ItemsAwarding(winItems);
                    StartCoroutine(fullparticle(winItems, winGold * m_boostGold));

                    winItems.Clear();
                }
            }
        }
        else if (comboType == ComboType.first)
        {
            List<Item> winItems = new List<Item>();
            long winGold = 0;
            int comboFull = 0;


            // фул комбо 
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].isOpened && slots[i].m_currentHero != null)
                {
                    if (slots[i].GetDice().currentCube.edges[slots[i].GetDice().currentWinIndex].edgeType == EdgeScript.EdgeType.Luck)
                    {
                        Debug.Log("item dropped =  " + slots[i].GetDice().prize);
                        for (int j = 0; j < m_boostItem; j++)
                        {
                            winItems.Add(slots[i].GetDice().winItem);
                        }
                        raidControl.GetParticles().PlayParticleWitItem(i, slots[i].GetDice().winItem);
                        winGold += slots[i].m_currentHero.GetGoldProfit() * slots[i].m_currentHero.GetCombo();
                    }
                    else if (slots[i].GetDice().currentCube.edges[slots[i].GetDice().currentWinIndex].edgeType == EdgeScript.EdgeType.Neutral)
                    {
                        Debug.Log("gold dropped =  " + slots[i].GetDice().prize);
                        winGold += slots[i].m_currentHero.GetNeutralGold() * slots[i].m_currentHero.GetCombo();
                        raidControl.GetParticles().PlayParticleWitoutItem(i);
                    }
                    else if (slots[i].GetDice().currentCube.edges[slots[i].GetDice().currentWinIndex].edgeType == EdgeScript.EdgeType.Unluck)
                    {
                        Debug.Log("DEATH dropped =  " + slots[i].GetDice().prize);
                    }
                }

                comboFull += slots[i].m_currentHero.GetCombo();
            }


            Gold.AddGold(winGold * m_boostGold);
            Debug.Log(winGold * m_boostGold + " gold from raid");
            GoldAwarding(winGold * m_boostGold);
            ItemsAwarding(winItems);
            StartCoroutine(fullparticle(winItems, winGold * m_boostGold));

        }
    }
    private bool CheckFullCombo(List<Raid_UI> slots)
    {
        bool isFullCombo = false;
        if (slots[0].GetDice().prize == DiceControll.Prize.Item)
        {
            isFullCombo = true;
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].GetDice().prize != DiceControll.Prize.Item)
                {
                    isFullCombo = false;
                    return isFullCombo;
                }
            }
            return isFullCombo;
        }
        else
            return isFullCombo;
        
    }
    private void ItemsAwarding(List<Item> winItems)
    {
        for (int i = 0; i < winItems.Count; i++)
        {
            inventory_Controll.ReturnItem(winItems[i]);
        }
        questControll.RaidCount();
        boost_Controll.RaidComplete();
        raid_Control.DisplayWinItems(winItems);
    }
    private void GoldAwarding(long value)
    {
        questControll.RaidConplete(value);
        raid_Control.DisplayWinGold(value);
    }
    public void GoldBoostActivate(int value) => m_boostGold = value;
    public void ItemBoostActivate(int value) => m_boostItem = value;
    public void GoldBoostDeActivate() => m_boostGold = 1;
    public void ItemBoostDeActivate() => m_boostItem = 1;

    IEnumerator fullparticle(List<Item> items, long gold)
    {
        Debug.Log("START PARTICLES");
        yield return new WaitForSeconds(1f);
        if(items.Count > 0)
        {
            fullParticlesToInv.PlayParticleWitItem(items);
        }
        else if(gold > 0)
        {
            fullParticlesToInv.PlayParticleWitoutItem();
        }
    }
}
