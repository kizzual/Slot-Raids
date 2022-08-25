using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TutorialFingerAlpha : MonoBehaviour
{
    public Button button;
    public void Click()
    {
        button.onClick?.Invoke();
    }

}
