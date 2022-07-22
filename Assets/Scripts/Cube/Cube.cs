using UnityEngine;

public class Cube : MonoBehaviour
{
    public EdgeScript[] edges;
    public int edgesNumber;
    [SerializeField] private  Rotate rotate;

    public void SwitchColors(int redCount, int greenCount)
    {
        foreach (var item in edges)
        {
            item.MakeGrey();
        }

        int luck = 0;
        int unLuck = 0;
 
        while (luck < greenCount )
        {
            int rng = Random.Range(0, edges.Length);
            if (edges[rng].edgeType == EdgeScript.EdgeType.Neutral)
            {
                edges[rng].MakeGreen();
                luck++;
            }
        }

        while (unLuck < redCount )
        {
            int rng = Random.Range(0, edges.Length);
            if (edges[rng].edgeType == EdgeScript.EdgeType.Neutral)
            {
                edges[rng].MakeRed();
                unLuck++;
            }
        }
        //Проверка какие грани красить
        // смена цветов
    }
    public void StartRotate(int winIndex) => rotate.StartRotate(winIndex);
    public int GetEdgesNumber() => edgesNumber;

    
}

    
