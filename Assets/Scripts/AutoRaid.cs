using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoRaid : MonoBehaviour
{
    [SerializeField] private Text timer;
    [SerializeField] private float Duration;
    [SerializeField] private Raid_button raid_button;

    [SerializeField] private Animator PlayeBut_anim;
    [SerializeField] private Animator PauseBut_anim;
    private float m_timer;
    private bool m_isActive;

    void FixedUpdate()
    {
        if(m_isActive)
        {
            m_timer += Time.fixedDeltaTime;
            TimeSpan ts = TimeSpan.FromSeconds(Duration - m_timer);
            timer.text = ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            if (m_timer >= Duration)
            {
                PauseRaid();
                raid_button.GoToAutoRaid();
            }
        }
    }
    public void ActivateButton()
    {
        raid_button.GoToAutoRaid();
        raid_button.isAutoRaid_boost = true;
        m_isActive = true;
        m_timer = 0;
        PlayeBut_anim.SetBool("IsActive", true);
        PauseBut_anim.SetBool("IsActive", false);
        timer.gameObject.SetActive(true);

        // animatioan start
    }
    public void PauseRaid()
    {
        raid_button.PauseRaid();
        raid_button.isAutoRaid_boost = false;
        m_isActive = false;
        m_timer = 0;
        PlayeBut_anim.SetBool("IsActive", false);
        PauseBut_anim.SetBool("IsActive", true);
        timer.gameObject.SetActive(false);
        // animatioan pause
    }
}
