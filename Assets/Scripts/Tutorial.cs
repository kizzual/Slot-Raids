using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> toturialsObj;
    [SerializeField] private Image RaidButton;
    private static int currentStep = 0;
    public static bool IsActiveSecondSteps;
    public void ActivateEvent()
    {
        GlovalEventSystem.OnTutorialSteps += TutorialSteps;
        GlovalEventSystem.OnTutorialStepsSecondPart += TutorialsSecondSteps;
        GlovalEventSystem.OnTutorialStepsThirdPart += TutorialsThirdSteps;
    }
    private void TutorialSteps(int stepNumber)
    {
        if(stepNumber == currentStep + 1)
        {
            toturialsObj[currentStep].SetActive(false);
            currentStep++;
            PlayerPrefs.SetInt("Tutorial", currentStep);
            if (currentStep == 9)
            {
                GlovalEventSystem.OnTutorialSteps -= TutorialSteps;
                foreach (var item in toturialsObj)
                {
                    item.SetActive(false);
                }
            }
            else
            {
                toturialsObj[currentStep].SetActive(true);
            }
        }
    }
    private void TutorialsSecondSteps(int stepNumber)
    {
        if(stepNumber + 1 == currentStep  )
        { 
            IsActiveSecondSteps = true;
            currentStep++;
            if (currentStep == 10)
            {
                toturialsObj[9].SetActive(true);
                RaidButton.raycastTarget = false;   
            }
            else if (currentStep == 11)
            {
                toturialsObj[9].SetActive(false);
                toturialsObj[10].SetActive(true);
            }
            else if (currentStep == 12)
            {
                toturialsObj[9].SetActive(false);
                toturialsObj[10].SetActive(false);
                RaidButton.raycastTarget = true;
                IsActiveSecondSteps = false;
            }
        }

    }
    private void TutorialsThirdSteps(int stepNumber)
    {
        if (stepNumber + 1 == currentStep )
        {
            currentStep++;
            if(currentStep == 13)
            {
                toturialsObj[11].SetActive(true);
            }
            else if(currentStep == 14)
            {
                toturialsObj[11].SetActive(false);
                toturialsObj[12].SetActive(true);
            }
            else if (currentStep == 15)
            {
                toturialsObj[12].SetActive(false);
                toturialsObj[13].SetActive(true);
            }
            else if (currentStep == 16)
            {
                toturialsObj[13].SetActive(false);
                toturialsObj[14].SetActive(true);
            }
            else if (currentStep == 17)
            {
                toturialsObj[14].SetActive(false);
                toturialsObj[15].SetActive(true);
            }
            else if (currentStep == 18)
            {
                toturialsObj[15].SetActive(false);
                toturialsObj[16].SetActive(true);
                toturialsObj[17].SetActive(true);
            }
            else if (currentStep == 19)
            {
                toturialsObj[16].SetActive(false);
                toturialsObj[17].SetActive(false);
            }

        }
        Debug.Log(currentStep + "   == Current step THIRD PART");


    }
    private void OnEnable()
    {
       /* if (PlayerPrefs.HasKey("Tutorial"))
            currentStep = PlayerPrefs.GetInt("Tutorial");
        else
            currentStep = 0;*/
        foreach (var item in toturialsObj)
        {
            item.SetActive(false);
        }
        toturialsObj[currentStep].SetActive(true);
    }
    public static int CheckTutorStep() => currentStep;

}
