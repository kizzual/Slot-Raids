using System.Collections.Generic;
using UnityEngine;

public class DiceControll : MonoBehaviour
{
    [SerializeField] private List<Cube> dices;
    private Hero m_currentHero { get; set; }
    public enum Prize
    {
        Death,
        Gold,
        Item
    }
    public Prize prize;
    public Item winItem { get; set; }
    public Cube currentCube { get; set; }
    private int currentWinIndex;

    public void OpenCurrentDice(Hero hero)
    {
        m_currentHero = hero;
        for (int i = 0; i < dices.Count; i++)
        {
            if(hero.cube.GetEdgesNumber() == dices[i].GetEdgesNumber())
            {
                dices[i].gameObject.SetActive(true);
                currentCube = dices[i];
            }
            else
                dices[i].gameObject.SetActive(false);
        }
        CheckColors();
    }
    private void CheckColors()
    {
        int luckCount = Mathf.RoundToInt((currentCube.edgesNumber / 100f) * m_currentHero.GetLuckProfit());
        int UnLuckCount = Mathf.RoundToInt((currentCube.edgesNumber / 100f) * m_currentHero.GetUnLuckProfit());
        currentCube.SwitchColors(UnLuckCount, luckCount);

        //проверка % лак и анлак у героя
        //Передача кубу количество цветовых граней
    }
    public void CheckRandomIndex()
    {
        currentWinIndex = Random.Range(0, currentCube.edges.Length );  // возможно +1 убрать    !!!!
        CurrentWinPrize();
    }
    public void StartRotate() => currentCube.StartRotate(currentWinIndex);
    public void StopRotate() => currentCube.StopRaid();
    private void CurrentWinPrize()
    {
   //     Debug.Log(currentCube.edges[currentWinIndex].edgeIndex, gameObject);
    //    Debug.Log(currentCube.edges[currentWinIndex].edgeType, gameObject);
        if (currentCube.edges[currentWinIndex  ].edgeType == EdgeScript.EdgeType.Neutral)
        {
            //формула голды
            prize = Prize.Gold;
        }
        else if (currentCube.edges[currentWinIndex  ].edgeType == EdgeScript.EdgeType.Luck)
        {
            //формула айтема рандомного
            winItem = CurrentZone.Current_Zone.ItemsOnZone[Random.Range(0, CurrentZone.Current_Zone.ItemsOnZone.Count)];
            prize = Prize.Item;
        }
        else if (currentCube.edges[currentWinIndex  ].edgeType == EdgeScript.EdgeType.Unluck)
            prize = Prize.Death;
    }
}
