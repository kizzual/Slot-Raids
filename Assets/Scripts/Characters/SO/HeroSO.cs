using UnityEngine;

[CreateAssetMenu(fileName = "HeroesSO", menuName = "ScriptableObjects/HeroesSO", order = 1)]
public class HeroSO : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite imageRank_1;
    public Sprite imageRank_2;
    public Sprite imageRank_3;

    public enum ElementType
    {
        Neutral,
        Undead,
        Order,
        Demon
    }
    public ElementType elementType;


    public int Level;

    public float goldToGrade;

    public int ProfitPercent;
    public int LuckPercent;
    public int ProtectPercent;
    public int ComboPercent;

    public int ItemProfit;
    public int ItemProtect;
    public int iemLuck;

}
