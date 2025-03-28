using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_UI : MonoBehaviour
{
    [SerializeField] private Text GradeCount;
    [SerializeField] private Text GoldToGrade;

    [SerializeField] private GameObject InActiveButton;

    [SerializeField] private List<Image> GradeTower_image;
    
    public void ChangeTowerSprite(int gradeNumber, long goldToGrade)
    {
        for (int i = 0; i < gradeNumber; i++)
        {
            GradeTower_image[i].gameObject.SetActive(true);

        }
        GradeCount.text = gradeNumber.ToString() + "/" + 9.ToString() + " SLOTS";
        GoldToGrade.text = ConvertText.FormatNumb(goldToGrade);
        if(Gold.GetCurrentGold() >= goldToGrade)
        {
            InActiveButton.SetActive(false);
        }
        else
        {
            InActiveButton.SetActive(true);
        }
    }

}
