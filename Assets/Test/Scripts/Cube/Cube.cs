using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float greenEdgeCount;
    public float redEdgeCount;
    public Rotate rotate;

    public EdgeScript[] edges;
    public void Test()
    {
        int x = 0;
        while (x < 10)
        {
            int randomIndex = Random.Range(0, edges.Length);
            if (edges[randomIndex].edgeType == EdgeScript.EdgeType.Neutral)
            {
                edges[randomIndex].MakeGreen();
                rotate.StartRotate(Random.Range(0, edges.Length));
                return;
            }
            x++;
        }
    }
}

    
