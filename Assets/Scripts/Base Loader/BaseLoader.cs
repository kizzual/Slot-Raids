using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLoader : MonoBehaviour
{
    [SerializeField] private Pause pause;
    [SerializeField] private Saver saver;
    [SerializeField] private CheckCombo checkCombo;
    [SerializeField] private QuestControll questControll;
    [SerializeField] private List<ParticleAdaptive> particleAdaptive;
    [SerializeField] private List<CheckOneTutuor> miniTutorials;

    void Awake()
    {
        LoadAllSystem();
        for (int i = 0; i < particleAdaptive.Count; i++)
        {
            particleAdaptive[i].Initialise();
        }
    }
    private void Start()
    {
        checkCombo.CheckOfflinePrize();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            if (MainTutorial.instance.mainTutorIsEnded &&
                MainTutorial.instance.secondTutorIsEnded &&
                MainTutorial.instance.thirdTutorIsEnded)
            {
                Utils.SetLastTime("LastSession");
                saver.FullSave();
            }
        }
        else
        {
            checkCombo.CheckOfflinePrize();
        }

    }
    private void LoadAllSystem()
    {
        for (int i = 0; i < miniTutorials.Count; i++)
        {
            miniTutorials[i].CheckSave();
        }
        saver.TutorialLoad();
        questControll.InitialiseQuest();
        pause.CheckSave();
        saver.MapLoad();
        saver.MapStatsLoad();
        saver.InventoryLoad();
        saver.HeroLoad();
        saver.BoostLoadBoostLoad();
        saver.QuestSystemLoad();
        if(!PlayerPrefs.HasKey("FirstQuestEvent"))
        {
            questControll.FirstInitializeEvent();
            PlayerPrefs.SetInt("FirstQuestEvent", 1);
        }
    }
    public void SaveAll()
    {
        saver.FullSave();
        
    }
}
