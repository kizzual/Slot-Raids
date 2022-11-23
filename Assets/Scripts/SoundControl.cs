using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public static SoundControl _instance;
    [SerializeField] private AudioClip startRaid;
    [SerializeField] private AudioClip ActiveBoost;
    [SerializeField] private AudioClip DeActiveBoost;
    [SerializeField] private AudioClip noMoney;
    [SerializeField] private AudioClip clickBTN;
    [SerializeField] private AudioClip autoRaid;
    [SerializeField] private AudioClip cash;
    [SerializeField] private AudioClip upgradeTower;
    [SerializeField] private AudioClip upgradeHero;
    [SerializeField] private AudioClip reward;
    [SerializeField] private AudioClip combo;
    [SerializeField] private AudioSource source;
    private bool m_raidIsMute = false;
    void Awake()
    {
        _instance = this;
    }


    public void StartRaidSound()
    {
        if(!m_raidIsMute)
            source.PlayOneShot(startRaid);
    }
    public void ActivateBoost() => source.PlayOneShot(ActiveBoost);
    public void Cash()
    {
        if (!m_raidIsMute)
            source.PlayOneShot(cash);
    }
    public void PlayCash() => source.PlayOneShot(cash);

    public void DeActivateBoost() => source.PlayOneShot(DeActiveBoost);
    public void UpgradeTower() => source.PlayOneShot(upgradeTower);
    public void UpgradeHero() => source.PlayOneShot(upgradeHero);
    public void Reward() => source.PlayOneShot(reward);
    public void Combo() => source.PlayOneShot(combo);

    public void ClickBTN() => source.PlayOneShot(clickBTN);
    public void NoMoney() => source.PlayOneShot(noMoney);
    public void AutoRaid() => source.PlayOneShot(autoRaid);


    public void MuteSound() => m_raidIsMute = true;
    public void UnMuteSound() => m_raidIsMute = false;

}
