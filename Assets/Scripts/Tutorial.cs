using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> toturialsObj;
    [SerializeField] private Image RaidButton;
    [SerializeField] private NewTutorialSystem newTutorialSystem;
    private static int currentStep = 0;
    public static bool IsActiveFirstSteps;

  //  public static bool IsActiveSecondSteps;
    public void ActivateEvent()
    {
        GlovalEventSystem.OnTutorialSteps += TutorialStep;
        GlovalEventSystem.OnTutorialStepsSecondPart += TutorialStep;
        GlovalEventSystem.OnTutorialStepsThirdPart += TutorialStep;
    }
    public void DeActivateEvent()
    {
        GlovalEventSystem.OnTutorialSteps -= TutorialStep;
        GlovalEventSystem.OnTutorialStepsSecondPart -= TutorialStep;
        GlovalEventSystem.OnTutorialStepsThirdPart -= TutorialStep;
    }
    /* private void TutorialSteps(int stepNumber)
     {
         if(stepNumber == currentStep + 1)
         {
             toturialsObj[currentStep].SetActive(false);
             currentStep++;
             PlayerPrefs.SetInt("Tutorial", currentStep);
             if (currentStep == 10)
             {
                 GlovalEventSystem.OnTutorialSteps -= TutorialSteps;
                 foreach (var item in toturialsObj)
                 {
                     item.SetActive(false);
                 }
             }
             else if(currentStep == 9 )
             {
                 StartCoroutine(SecondTabToPlay());
             }
             else
             {
                 toturialsObj[currentStep].SetActive(true);
             }
         }
     }*/
    /*  private void TutorialsSecondSteps(int stepNumber)
      {
          if(stepNumber + 1 == currentStep  )
          { 
              IsActiveSecondSteps = true;
              currentStep++;
              if (currentStep == 11)
              {
                  toturialsObj[10].SetActive(true);
                  RaidButton.raycastTarget = false;   
              }
              else if (currentStep == 12)
              {
                  toturialsObj[10].SetActive(false);
                  toturialsObj[11].SetActive(true);
              }
              else if (currentStep == 13)
              {
                  toturialsObj[10].SetActive(false);
                  toturialsObj[11].SetActive(false);
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
              if (currentStep == 14)
              {
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
              }
              else if (currentStep == 19)
              {
                  toturialsObj[16].SetActive(false);
                  toturialsObj[17].SetActive(true);
                  toturialsObj[18].SetActive(true);
              }
              else if (currentStep == 20)
              {
                  toturialsObj[17].SetActive(false);
                  toturialsObj[18].SetActive(false);
                  toturialsObj[19].SetActive(true);
              }
              else if(currentStep == 21)
              {
                  toturialsObj[19].SetActive(false);
              }

          }


      }*/

    public void TutorialStep(int step)
    {
     //   Debug.Log("STEP = " + step);
     //   Debug.Log("currentStep = " + currentStep);
        if(step != 14)
        {
            foreach (var item in toturialsObj)
        {
            item.SetActive(false);
        }
        }
        if (currentStep < toturialsObj.Count)
        {
            if (step == currentStep)
            {
              
                toturialsObj[step].SetActive(true);

                if (currentStep == 9)
                {
                    toturialsObj[step].SetActive(false);
                    StartCoroutine(SecondTabToPlay());
                }
                if (currentStep == 11)
                {
                //    IsActiveSecondSteps = true;
                    RaidButton.raycastTarget = false;
                }
                if (currentStep == 13)
                {
                   // IsActiveSecondSteps = false;
                    RaidButton.raycastTarget = true;
                    toturialsObj[currentStep - 1].SetActive(false);
                    newTutorialSystem.StepByStep(0);
                }
               if(currentStep == 19)
                {
                    toturialsObj[step + 1].SetActive(true);
                }
               if(currentStep == 20)
                {
                    toturialsObj[19].SetActive(false);
                    toturialsObj[20].SetActive(false);
                    toturialsObj[step + 1].SetActive(true);
                }
               if(currentStep == 21)
                {
                    foreach (var item in toturialsObj)
                    {
                        item.SetActive(false);
                    }
                }
                currentStep++;
                PlayerPrefs.SetInt("Tutorial", currentStep);
            }
        }
    }
    IEnumerator SecondTabToPlay()
    {
        yield return new WaitForSeconds(3f);
        toturialsObj[currentStep - 1].SetActive(true);
    }
    private void OnEnable()
    {
        foreach (var item in toturialsObj)
        {
            item.SetActive(false);
        }

        if (PlayerPrefs.HasKey("Tutorial"))
            currentStep = PlayerPrefs.GetInt("Tutorial") - 1;
        else
            currentStep = 0;

        TutorialStep(currentStep);
    }
    public static int CheckTutorStep() => currentStep;

}
