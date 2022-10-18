using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLoader : MonoBehaviour
{
    [SerializeField] private Pause pause;
    [SerializeField] private Saver saver;
    [SerializeField] private CheckCombo checkCombo;
    [SerializeField] private List<ParticleAdaptive> particleAdaptive;

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
            Utils.SetLastTime("LastSession");
            saver.FullSave();
        }

    }
    private void LoadAllSystem()
    {
        pause.CheckSave();
        saver.MapLoad();
        saver.MapStatsLoad();
        saver.InventoryLoad();
        saver.HeroLoad();
        saver.BoostLoadBoostLoad();
        saver.QuestSystemLoad();
    }

}
