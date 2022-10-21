using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOneTutuor : MonoBehaviour
{
    [SerializeField] private string PrefName;
    [SerializeField] private List<GameObject> steps;
    [SerializeField] private int numSteps = 0;
     public void StepTutor()
    {
        if (numSteps != steps.Count)
        {
            if (numSteps > 0)
            {
                steps[numSteps - 1].SetActive(false);
                steps[numSteps].SetActive(true);
            }
            else
            {
                steps[numSteps].SetActive(true);
            }
            numSteps++;
        }
        else
        {
            steps[numSteps - 1].SetActive(false);
            PlayerPrefs.SetInt(PrefName, 1);
            Debug.Log(PlayerPrefs.GetInt(PrefName));
        }
    }
    public void CheckSave()
    {
        if (PlayerPrefs.HasKey(PrefName))
            gameObject.SetActive(false);
        else
            StepTutor();
    }
}
