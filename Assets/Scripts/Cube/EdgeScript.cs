using UnityEngine;

public class EdgeScript : MonoBehaviour
{
    public EdgeType edgeType;
    public int edgeIndex;
    public enum EdgeType
    {
        Neutral,
        Luck,
        Unluck
    }
    public void MakeGreen()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        edgeType = EdgeType.Luck;
    }
    public void MakeRed()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        edgeType = EdgeType.Unluck;
    }
    public void MakeGrey()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        edgeType = EdgeType.Neutral;
    }
}
