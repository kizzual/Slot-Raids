using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private static SceneTransition instance;
    private AsyncOperation loadintSceneOperation;
  //  [SerializeField] private Slider slider;

    private float currentValue;
    private float targetValue;
    private float progressAnimationMultiplier = 0.25f;
    public static void SwitchToScene(int sceneIndex)
    {
        instance.loadintSceneOperation = SceneManager.LoadSceneAsync(sceneIndex);
        instance.loadintSceneOperation.allowSceneActivation = false;
    }

    void Start()
    {
        instance = this;

        SwitchToScene(1);
    }

    void Update()
    {

        if (loadintSceneOperation != null)
        {
            targetValue = loadintSceneOperation.progress / 0.9f;
            currentValue = Mathf.MoveTowards(currentValue, targetValue, progressAnimationMultiplier * Time.deltaTime);

      //      slider.value = currentValue;
            if (Mathf.Approximately(currentValue, 1))
            {
                loadintSceneOperation.allowSceneActivation = true;
            }

        }
    }

    public void OnAnimationOver()
    {
        loadintSceneOperation.allowSceneActivation = true;
    }
}
