using System.Collections.Generic;
using UnityEngine;

public class DiceControll : MonoBehaviour
{
    [SerializeField] private List<Cube> dices;
    public ParticleSystem LuckParticle;
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
    public void SetLuckPrize()
    {
         for (int i = 0; i < currentCube.edges.Length; i++)
         {
             if (currentCube.edges[i].edgeType == EdgeScript.EdgeType.Luck)
             {
                 currentWinIndex = i;
                 break;
             }

         }
        CurrentWinPrize();
    }
    public void SetUnLuckPrize()
    {
          for (int i = 0; i < currentCube.edges.Length; i++)
          {
              if (currentCube.edges[i].edgeType == EdgeScript.EdgeType.Unluck)
              {
                  currentWinIndex = i;
                  break;
              }
          }
        CurrentWinPrize();
    }
    public void StartRotate() => currentCube.StartRotate(currentWinIndex);
    public void StopRotate() => currentCube.StopRaid();
    private void CurrentWinPrize()
    {
        Debug.Log(currentCube.edges[currentWinIndex].edgeIndex, gameObject);
        Debug.Log(currentCube.edges[currentWinIndex].edgeType, gameObject);
        if (currentCube.edges[currentWinIndex  ].edgeType == EdgeScript.EdgeType.Neutral)
        {
            //формула голды
            prize = Prize.Gold;
        }
        else if (currentCube.edges[currentWinIndex  ].edgeType == EdgeScript.EdgeType.Luck)
        {
            //формула айтема рандомного
            int random = Random.Range(0, 10);
            if (random < 5)
                winItem = CurrentZone.Current_Zone.ItemsOnZone[0];
            else
                winItem = CurrentZone.Current_Zone.ItemsOnZone[1];
            prize = Prize.Item;
        }
        else if (currentCube.edges[currentWinIndex  ].edgeType == EdgeScript.EdgeType.Unluck)
            prize = Prize.Death;
    }
}
